using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrianglePiece : MonoBehaviour
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

    [SerializeField] private GameObject VisualObject;

    private TrianglePieceVisual trianglePieceVisual;
    

    public enum PieceType
    {
        SwirlLeft,
        SwirlRight,
        Ray
    }

    public enum PieceColor
    {
        Transparent,
        Black,
        White,
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Magenta,
        Purple,

    }

    // Start is called before the first frame update
    void Start()
    {
        
        trianglePieceVisual = VisualObject.GetComponent<TrianglePieceVisual>();

        SetPieceType(GetRandomPieceType());
        SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        SetBackgroundColors(PieceColor.Black);

        SetOutlineColor(PieceColor.Black);
        OutlineOff();

        SetGlowColor(GetRandomPieceColor());
        GlowOn();

        //Debug.Log(("[{0}]", string.Join(", ", GetPieceColors())));

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (.3f) * Time.deltaTime, transform.position.y, transform.position.z);

    }

    private void SetPieceType(PieceType pieceType)
    {
        this.pieceType = pieceType;
        switch (pieceType)
        {
            case PieceType.SwirlLeft:
                trianglePieceVisual.SetSwirlLeft();
                break;
            case PieceType.SwirlRight:
                trianglePieceVisual.SetSwirlRight();
                break;
            case PieceType.Ray:
                trianglePieceVisual.SetRay();
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
            new PieceColor[] { Side1Color, Side2Color, Side3Color },
            new PieceColor[] { Side3Color, Side1Color, Side2Color },
            new PieceColor[] { Side2Color, Side3Color, Side1Color }

        };
    }

    public void SetPieceColors(PieceColor a_Color1, PieceColor a_Color2, PieceColor a_Color3)
    {
        Side1Color = a_Color1;
        Side2Color = a_Color2;
        Side3Color = a_Color3;

        trianglePieceVisual.SetSideColor(0, GetColor(Side1Color));
        trianglePieceVisual.SetSideColor(1, GetColor(Side1Color));
        trianglePieceVisual.SetSideColor(2, GetColor(Side2Color));
        trianglePieceVisual.SetSideColor(3, GetColor(Side3Color));
    }

    public void SetBackgroundColors(PieceColor a_Color1, PieceColor a_Color2, PieceColor a_Color3)
    {
        Background1Color = a_Color1;
        Background2Color = a_Color2;
        Background3Color = a_Color3;

        trianglePieceVisual.SetBackgroundColor(0, GetColor(Background1Color));
        trianglePieceVisual.SetBackgroundColor(1, GetColor(Background1Color));
        trianglePieceVisual.SetBackgroundColor(2, GetColor(Background2Color));
        trianglePieceVisual.SetBackgroundColor(3, GetColor(Background3Color));
    }

    public void SetBackgroundColors(PieceColor a_Color)
    {
        SetBackgroundColors(a_Color, a_Color, a_Color);
    }

    public void GlowOn()
    {
        trianglePieceVisual.ShowGlow();
    }

    public void GlowOff()
    {
        trianglePieceVisual.HideGlow();
    }

    public void SetGlowColor(PieceColor a_Color)
    {
        GlowColor = a_Color;
        trianglePieceVisual.SetGlowColor(GetColor(GlowColor) );
    }

    public void OutlineOn()
    {
        trianglePieceVisual.ShowOutline();
    }

    public void OutlineOff()
    {
        trianglePieceVisual.HideOutline();
    }

    public void SetOutlineColor(PieceColor a_Color)
    {
        OutlineColor = a_Color;
        trianglePieceVisual.SetOutlineColor(GetColor(OutlineColor));
    }
    private PieceColor GetRandomPieceColor()
    {
        Array _EnumValues = Enum.GetValues(typeof(PieceColor));
        int _RandomIndex = UnityEngine.Random.Range(2, _EnumValues.Length);
        PieceColor _RandomPieceColor = (PieceColor)_EnumValues.GetValue(_RandomIndex);

        Debug.Log("Random Index: " + _RandomIndex);

        return _RandomPieceColor;
    }

    private PieceType GetRandomPieceType()
    {
        Array _EnumValues = Enum.GetValues(typeof(PieceType));
        int _RandomeIndex = UnityEngine.Random.Range(0, _EnumValues.Length);
        PieceType _RandomPieceType = (PieceType)_EnumValues.GetValue(_RandomeIndex);

        return _RandomPieceType;
    }

    private float NormalizeNumber(int a_Number)
    {
        return a_Number / 255f;
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
            //case PieceColor.Orange:
            //    return new Color(NormalizeNumber(225), NormalizeNumber(165), NormalizeNumber(0), 1);
            case PieceColor.Purple:
                return new Color(NormalizeNumber(160), NormalizeNumber(32), NormalizeNumber(240), 1);
            //case PieceColor.Pink:
            //    return new Color(NormalizeNumber(255), NormalizeNumber(192), NormalizeNumber(203), 1);
            //case PieceColor.LightBlue:
            //    return new Color(NormalizeNumber(173), NormalizeNumber(216), NormalizeNumber(230), 1);
            //case PieceColor.LightGreen:
            //    return new Color(NormalizeNumber(144), NormalizeNumber(238), NormalizeNumber(144), 1);
            case PieceColor.Transparent:
                return new Color();
            default:
                return Color.black;
        }
    }

}
