using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrianglePieceManager : MonoBehaviour
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

    private TrianglePieceVisualManager TrianglePieceVisual;
    

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

    private void Awake()
    {
        TrianglePieceVisual = VisualObject.GetComponent<TrianglePieceVisualManager>();
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPieceType(PieceType pieceType)
    {
        this.pieceType = pieceType;
        switch (pieceType)
        {
            case PieceType.SwirlLeft:
                TrianglePieceVisual.SetSwirlLeft();
                break;
            case PieceType.SwirlRight:
                TrianglePieceVisual.SetSwirlRight();
                break;
            case PieceType.Ray:
                TrianglePieceVisual.SetRay();
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

    public void SetVisible(bool a_Active)
    {
        VisualObject.SetActive(a_Active);
    }

    public void Show()
    {
        VisualObject.SetActive(true);
    }

    public void Hide()
    {
        VisualObject.SetActive(false);
    }

    public void SetPieceColors(PieceColor a_Color1, PieceColor a_Color2, PieceColor a_Color3)
    {
        Side1Color = a_Color1;
        Side2Color = a_Color2;
        Side3Color = a_Color3;

        TrianglePieceVisual.SetSideColor(0, GetColor(Side1Color));
        TrianglePieceVisual.SetSideColor(1, GetColor(Side1Color));
        TrianglePieceVisual.SetSideColor(2, GetColor(Side2Color));
        TrianglePieceVisual.SetSideColor(3, GetColor(Side3Color));
    }

    public void SetBackgroundColors(PieceColor a_Color1, PieceColor a_Color2, PieceColor a_Color3)
    {
        Background1Color = a_Color1;
        Background2Color = a_Color2;
        Background3Color = a_Color3;

        TrianglePieceVisual.SetBackgroundColor(0, GetColor(Background1Color));
        TrianglePieceVisual.SetBackgroundColor(1, GetColor(Background1Color));
        TrianglePieceVisual.SetBackgroundColor(2, GetColor(Background2Color));
        TrianglePieceVisual.SetBackgroundColor(3, GetColor(Background3Color));
    }

    public void SetBackgroundColor(PieceColor a_Color)
    {
        SetBackgroundColors(a_Color, a_Color, a_Color);
    }

    public void ShowGlow()
    {
        TrianglePieceVisual.ShowGlow();
    }

    public void HideGlow()
    {
        TrianglePieceVisual.HideGlow();
    }

    public void EnableGlow(bool a_GlowEnable)
    {
        TrianglePieceVisual.EnableGlow(a_GlowEnable);
    }

    public void SetGlowColor(PieceColor a_Color)
    {
        GlowColor = a_Color;
        TrianglePieceVisual.SetGlowColor(GetColor(GlowColor) );
    }

    public void ShowOutline()
    {
        TrianglePieceVisual.ShowOutline();
    }

    public void HideOutline()
    {
        TrianglePieceVisual.HideOutline();
    }

    public void EnableOutline(bool a_OutlineEnable)
    {
        TrianglePieceVisual.EnableOutline(a_OutlineEnable);
    }

    public void SetOutlineColor(PieceColor a_Color)
    {
        OutlineColor = a_Color;
        TrianglePieceVisual.SetOutlineColor(GetColor(OutlineColor));
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
