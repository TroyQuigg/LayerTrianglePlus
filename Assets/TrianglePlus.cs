using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrianglePlus : MonoBehaviour
{
    [SerializeField] private PieceType pieceType;
    [SerializeField] private PieceColor Side1Color;
    [SerializeField] private PieceColor Side2Color;
    [SerializeField] private PieceColor Side3Color;

    [SerializeField] private PieceColor Background1Color;
    [SerializeField] private PieceColor Background2Color;
    [SerializeField] private PieceColor Background3Color;

    [SerializeField] private PieceColor GlowColor;
    [SerializeField] private PieceColor OutlineColor;


    private TrianglePlusVisual trianglePlusVisual;
    private GameObject Visual;

    public enum PieceType
    {
        SwirlLeft,
        SwirlRight,
        Ray
    }

    public enum PieceColor
    {
        Transparent,
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Magenta,
        Purple,
        Orange,
        Pink,
        LightBlue,
        LightGreen
    }

    // Start is called before the first frame update
    void Start()
    {
        trianglePlusVisual = GameObject.Find("Visual").GetComponent<TrianglePlusVisual>();

        SetPieceType(PieceType.SwirlRight);
        SetPieceColors(PieceColor.Red, PieceColor.Green, PieceColor.Blue);
        SetBackgroundColors(PieceColor.Transparent);

        SetOutlineColor(PieceColor.Black);
        OutlineOn();

        SetGlowColor(PieceColor.Yellow);
        GlowOff();     

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (.1f) * Time.deltaTime, transform.position.y, transform.position.z);

    }

    private void SetPieceType(PieceType pieceType)
    {
        this.pieceType = pieceType;
        switch (pieceType)
        {
            case PieceType.SwirlLeft:
                trianglePlusVisual.SetSwirlLeft();
                break;
            case PieceType.SwirlRight:
                trianglePlusVisual.SetSwirlRight();
                break;
            case PieceType.Ray:
                trianglePlusVisual.SetRay();
                break;
        }
    }

    public PieceType GetPieceType() { return pieceType; }

    public PieceColor[] GetPieceColors()
    {
        return new PieceColor[] { Side1Color, Side2Color, Side3Color };
    }

    public PieceColor[] GetBackgroundColors()
    {
        return new PieceColor[] { Background1Color, Background2Color, Background3Color };
    }

    public List<PieceColor[]> GetPieceColorsAllCombinations()
    {
        return new List<PieceColor[]>
        {
            new PieceColor[] { Background1Color, Background2Color, Background3Color },
            new PieceColor[] { Background3Color, Background1Color, Background2Color },
            new PieceColor[] { Background2Color, Background3Color, Background1Color }

        };
    }

    public void SetPieceColors(PieceColor a_Color1, PieceColor a_Color2, PieceColor a_Color3)
    {
        Side1Color = a_Color1;
        Side2Color = a_Color2;
        Side3Color = a_Color3;

        trianglePlusVisual.SetSideColor(0, GetColor(Side1Color));
        trianglePlusVisual.SetSideColor(1, GetColor(Side1Color));
        trianglePlusVisual.SetSideColor(2, GetColor(Side2Color));
        trianglePlusVisual.SetSideColor(3, GetColor(Side3Color));
    }

    public void SetBackgroundColors(PieceColor a_Color1, PieceColor a_Color2, PieceColor a_Color3)
    {
        Background1Color = a_Color1;
        Background2Color = a_Color2;
        Background3Color = a_Color3;

        trianglePlusVisual.SetBackgroundColor(0, GetColor(Background1Color));
        trianglePlusVisual.SetBackgroundColor(1, GetColor(Background1Color));
        trianglePlusVisual.SetBackgroundColor(2, GetColor(Background2Color));
        trianglePlusVisual.SetBackgroundColor(3, GetColor(Background3Color));
    }

    public void SetBackgroundColors(PieceColor a_Color)
    {
        SetBackgroundColors(a_Color, a_Color, a_Color);
    }

    public void GlowOn()
    {
        trianglePlusVisual.ShowGlow();
    }

    public void GlowOff()
    {
        trianglePlusVisual.HideGlow();
    }

    public void SetGlowColor(PieceColor a_Color)
    {
        GlowColor = a_Color;
        trianglePlusVisual.SetGlowColor(GetColor(GlowColor) );
    }

    public void OutlineOn()
    {
        trianglePlusVisual.ShowOutline();
    }

    public void OutlineOff()
    {
        trianglePlusVisual.HideOutline();
    }

    public void SetOutlineColor(PieceColor a_Color)
    {
        OutlineColor = a_Color;
        trianglePlusVisual.SetOutlineColor(GetColor(OutlineColor));
    }
    private Color GetColor(PieceColor a_Color)
    {
        switch (a_Color)
        {
            case PieceColor.White:
                return Color.white;
            case PieceColor.Black:
                return Color.black;
            case PieceColor.Red:
                return Color.red;
            case PieceColor.Green:
                return Color.green;
            case PieceColor.Blue:
                return Color.blue;
            case PieceColor.Yellow:
                return Color.yellow;
            case PieceColor.Cyan:
                return Color.cyan;
            case PieceColor.Magenta:
                return Color.magenta;
            case PieceColor.Orange:
                return new Color(225, 165, 0);
            case PieceColor.Purple:
                return new Color(160, 32, 240);
            case PieceColor.Pink:
                return new Color(255, 192, 203);
            case PieceColor.LightBlue:
                return new Color(173, 216, 230);
            case PieceColor.LightGreen:
                return new Color(144, 238, 144);
            case PieceColor.Transparent:
                return new Color(0, 0, 0, 0);
            default:
                return Color.black;
        }
    }

}
