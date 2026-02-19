using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TrianglePieceManager;
using System.Linq;
using System.Text;

public class GameBoardManager : MonoBehaviour
{

    [SerializeField] private List<PieceData> GameBoardPieceList;

    private int TotalGamePieces;
    private float RotationDelta;
    
    // Start is called before the first frame update
    void Start()
    {
        TotalGamePieces = 36;
        RotationDelta = 120f;

        SetupBoardPieces();
        RandomRotation();
        RandomMovement();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator LerpMoveOverTime(PieceData a_GamePieceData, float a_Duration)
    {
        a_GamePieceData.IsMoving = true;
        for (float t = 0f; t < a_Duration; t += Time.deltaTime)
        {
            a_GamePieceData.TrianglePieceObject.transform.position = Vector3.Lerp(a_GamePieceData.CurrentPosition, a_GamePieceData.NewPosition, t / a_Duration);
            yield return 0;
        }
        a_GamePieceData.TrianglePieceObject.transform.position = a_GamePieceData.NewPosition;
        a_GamePieceData.CurrentPosition = a_GamePieceData.TrianglePieceObject.transform.position;
        a_GamePieceData.IsMoving = false;
    }

    private IEnumerator LerpRotateOverTime(PieceData a_GamePieceData, float a_Duration)
    {
        a_GamePieceData.IsRotating = true;
        for (float t = 0f; t < a_Duration; t += Time.deltaTime)
        {
            a_GamePieceData.TrianglePieceObject.transform.rotation = Quaternion.Lerp(a_GamePieceData.CurrentRotation, a_GamePieceData.NewRotation, t / a_Duration);
            yield return 0;
        }
        a_GamePieceData.TrianglePieceObject.transform.rotation = a_GamePieceData.NewRotation;
        a_GamePieceData.CurrentRotation = a_GamePieceData.TrianglePieceObject.transform.rotation;
        a_GamePieceData.IsRotating = false;
    }

    private PieceColor GetRandomPieceColor()
    {
        Array _EnumValues = Enum.GetValues(typeof(PieceColor));
        int _RandomEnumIndex = UnityEngine.Random.Range(2, _EnumValues.Length);
        PieceColor _RandomPieceColor = (PieceColor)_EnumValues.GetValue(_RandomEnumIndex);

        return _RandomPieceColor;
    }

    private PieceType GetRandomPieceType()
    {
        Array _EnumValues = Enum.GetValues(typeof(PieceType));
        int _RandomEnumIndex = UnityEngine.Random.Range(0, _EnumValues.Length);
        PieceType _RandomPieceType = (PieceType)_EnumValues.GetValue(_RandomEnumIndex);

        return _RandomPieceType;
    }

    private string GetPieceNameFromNumber(int a_Number)
    {
        StringBuilder _FullName = new StringBuilder();
        _FullName.Append("TriangleGamePiece_");

        switch (a_Number) {
            case int i when i >= 0 && i <=8:
                _FullName.Append("A0" + (a_Number + 1).ToString());
                break;
            case int i when i >= 9 && a_Number <= 17:
                _FullName.Append("B0" + (a_Number - 8).ToString());
                break;
            case int i when i >= 18 && a_Number <= 26:
                _FullName.Append("C0" + (a_Number - 17).ToString());
                break;
            case int i when i >= 27 && a_Number <= 35:
                _FullName.Append("D0" + (a_Number - 26).ToString());
                break;
        }
        
        return _FullName.ToString();
    }

    private void SetupBoardPieces()
    {
        GameBoardPieceList = new List<PieceData>();

        for (int i = 0; i < TotalGamePieces; i++)
        {
            GameObject _GameObject = GameObject.Find(GetPieceNameFromNumber(i));
            GameBoardPieceList.Add(new PieceData(_GameObject));
        }

        foreach (PieceData GamePiece in GameBoardPieceList)
        {
            GamePiece.SetPieceType(GetRandomPieceType());
            GamePiece.SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
            GamePiece.SetBackgroundColor(PieceColor.Black);
            GamePiece.SetOutlineColor(PieceColor.Black);
            GamePiece.EnableOutline(true);
            GamePiece.SetGlowColor(GetRandomPieceColor());
            GamePiece.EnableGlow(true);
        }
    }

    private void RandomMovement()
    {
        for (int j = 0; j < GameBoardPieceList.Count; j++)
        {
            for (int i = 0; i < TotalGamePieces; i++)
            {
                int _PieceIndex1 = UnityEngine.Random.Range(0, 32);
                int _PieceIndex2 = UnityEngine.Random.Range(0, 32);

                if (_PieceIndex1 != _PieceIndex2)
                {
                    if (GameBoardPieceList[_PieceIndex1].CurrentRotation == GameBoardPieceList[_PieceIndex2].CurrentRotation)
                    {
                        if ((GameBoardPieceList[_PieceIndex1].IsMoving == false) && (GameBoardPieceList[_PieceIndex2].IsMoving == false))
                        {
                            GameBoardPieceList[_PieceIndex1].IsMoving = true;
                            GameBoardPieceList[_PieceIndex2].IsMoving = true;
                            SwapPiece(GameBoardPieceList[_PieceIndex1], GameBoardPieceList[_PieceIndex2], UnityEngine.Random.Range(1, 5));
                        }
                    }
                }
            }
        }
    }

    private void RandomRotation()
    {
        for (int i = 0; i < TotalGamePieces; i++)
        {
            RotatePiece(GameBoardPieceList[i], RotationDelta, UnityEngine.Random.Range(1, 5));
        }
    }

    private void SwapPiece(PieceData a_GamePiece1, PieceData a_GamePiece2, float a_Speed)
    {
        a_GamePiece1.NewPosition = a_GamePiece2.CurrentPosition;
        a_GamePiece2.NewPosition = a_GamePiece1.CurrentPosition;

        StartCoroutine(LerpMoveOverTime(a_GamePiece1, a_Speed));
        StartCoroutine(LerpMoveOverTime(a_GamePiece2, a_Speed));
    }

    private void RotatePiece(PieceData a_GamePiece, float a_RotateAmount, float a_Speed)
    {
        a_GamePiece.NewRotation = Quaternion.Euler(0, 0, a_GamePiece.TrianglePieceObject.transform.rotation.eulerAngles.z + a_RotateAmount);
        StartCoroutine(LerpRotateOverTime(a_GamePiece, a_Speed));
    }

}

[System.Serializable]
public class PieceData
{
    public GameObject TrianglePieceObject;

    public Vector3 CurrentPosition;
    public Vector3 NewPosition;
    
    public Quaternion CurrentRotation;
    public Quaternion NewRotation;

    public float RotateAmount;

    public bool IsSelected;
    public bool IsMoving;
    public bool IsRotating;
    public bool IsEnabled { get => this._IsEnabled; private set => this._IsEnabled = value; }
    [SerializeField]
    private bool _IsEnabled = true;

    public bool IsVisible { get => this._IsVisible; private set => this._IsVisible = value; }
    [SerializeField]
    private bool _IsVisible = true;

    private TrianglePieceManager _TrianglePieceManager;
    
    public PieceData()
    {
        IsMoving = false;
        IsRotating = false;
        IsSelected = false;
    }

    public PieceData(GameObject a_TrianglePieceObject) : this()
    {
        CurrentPosition = a_TrianglePieceObject.transform.position;
        CurrentRotation = a_TrianglePieceObject.transform.rotation;
        TrianglePieceObject = a_TrianglePieceObject;
        AssignTrianglePieceManager();
    }

    public void AssignTrianglePieceManager()
    {
        _TrianglePieceManager = TrianglePieceObject.GetComponent<TrianglePieceManager>();
    }

    public void SetVisible(bool a_Visible)
    {
        IsVisible = a_Visible;
        _TrianglePieceManager?.SetVisible(a_Visible);
    }

    public void SetEnabled(bool a_Enabled)
    {
        IsEnabled = a_Enabled;
        TrianglePieceObject?.SetActive(a_Enabled);
        SetVisible(a_Enabled);
    }

    public string GetName()
    {
        return TrianglePieceObject != null ? TrianglePieceObject.name : null;
    }

    public void SetOutlineColor(PieceColor a_Color)
    {
        _TrianglePieceManager?.SetOutlineColor(a_Color);
    }

    public void EnableOutline(bool a_EnableOutline)
    {
        _TrianglePieceManager?.EnableOutline(a_EnableOutline);
    }

    public void EnableGlow(bool a_EnableGlow)
    {
        _TrianglePieceManager?.EnableGlow(a_EnableGlow);
    }

    public void SetGlowColor(PieceColor a_Color)
    {
        _TrianglePieceManager?.SetGlowColor(a_Color);
    }

    public void SetPieceType(PieceType a_PieceType)
    {
        _TrianglePieceManager?.SetPieceType(a_PieceType);
    }

    public void SetPieceColors(PieceColor a_Color1, PieceColor a_Color2, PieceColor a_Color3)
    {
        _TrianglePieceManager?.SetPieceColors(a_Color1, a_Color2, a_Color3);
    }

    public void SetBackgroundColor(PieceColor a_Color)
    {
        _TrianglePieceManager?.SetBackgroundColor(a_Color);
    }
}
