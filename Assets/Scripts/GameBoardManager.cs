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
    //[SerializeField] GameObject testGameObject;
    //[SerializeField] private TrianglePieceManager MyTrianglePieceManager;

    private int TotalGamePieces;

    private float RotationDelta;
    private float DeltaX;
    private float DeltaY;
    
    // Start is called before the first frame update
    void Start()
    {
        TotalGamePieces = 32;

        RotationDelta = 120f;

        DeltaX = 10f;
        DeltaY = 10f;

        SetupBoardPieces();

        //MyTrianglePieceManager = testGameObject.GetComponent<TrianglePieceManager>();

        //MyTrianglePieceManager.SetPieceType(GetRandomPieceType());
        //MyTrianglePieceManager.SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        //MyTrianglePieceManager.SetBackgroundColors(PieceColor.Black);
        //MyTrianglePieceManager.SetOutlineColor(PieceColor.Black);
        //MyTrianglePieceManager.OutlineOff();
        //MyTrianglePieceManager.SetGlowColor(GetRandomPieceColor());
        //MyTrianglePieceManager.GlowOn();


    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator LerpMoveOverTime(GameObject a_GameObject, PieceData a_PieceData, float a_Duration)
    {
        a_PieceData.IsMoving = true;
        for (float t = 0f; t < a_Duration; t += Time.deltaTime)
        {
            a_GameObject.transform.position = Vector3.Lerp(a_PieceData.CurrentPosition, a_PieceData.NewPosition, t / a_Duration);
            yield return 0;
        }
        a_GameObject.transform.position = a_PieceData.NewPosition;
        a_PieceData.CurrentPosition = a_GameObject.transform.position;
        a_PieceData.IsMoving = false;
    }

    IEnumerator LerpRotateOverTime(GameObject a_GameObject, PieceData a_PieceData, float a_Duration)
    {
        a_PieceData.IsRotating = true;

        for (float t = 0f; t < a_Duration; t += Time.deltaTime)
        {
            a_GameObject.transform.rotation = Quaternion.Lerp(a_PieceData.CurrentRotation, a_PieceData.NewRotation, t / a_Duration);
            yield return 0;
        }
        a_GameObject.transform.rotation = a_PieceData.NewRotation;
        a_PieceData.CurrentRotation = a_GameObject.transform.rotation;
        a_PieceData.IsRotating = false;
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
            case int i when i >= 0 && i <=7:
                _FullName.Append("A0" + (a_Number + 1).ToString());
                break;
            case int i when i >= 8 && a_Number <= 15:
                _FullName.Append("B0" + (a_Number - 7).ToString());
                break;
            case int i when i >= 16 && a_Number <= 23:
                _FullName.Append("C0" + (a_Number - 15).ToString());
                break;
            case int i when i >= 24 && a_Number <= 31:
                _FullName.Append("D0" + (a_Number - 23).ToString());
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
            float _Speed = UnityEngine.Random.Range(1, 5);

            TrianglePieceManager _TrianglePieceManager = GamePiece.TrianglePieceObject.GetComponent<TrianglePieceManager>();

            _TrianglePieceManager.SetPieceType(GetRandomPieceType());
            _TrianglePieceManager.SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
            _TrianglePieceManager.SetBackgroundColors(PieceColor.Black);
            _TrianglePieceManager.SetOutlineColor(PieceColor.Black);
            _TrianglePieceManager.OutlineOff();
            _TrianglePieceManager.SetGlowColor(GetRandomPieceColor());
            _TrianglePieceManager.GlowOn();

            GamePiece.NewPosition = new Vector3(GamePiece.TrianglePieceObject.transform.position.x + DeltaX, GamePiece.TrianglePieceObject.transform.position.y + DeltaY, GamePiece.TrianglePieceObject.transform.position.z);
            GamePiece.IsMoving = false;
            StartCoroutine(LerpMoveOverTime(GamePiece.TrianglePieceObject, GamePiece, _Speed));

            GamePiece.NewRotation = Quaternion.Euler(0, 0, GamePiece.TrianglePieceObject.transform.rotation.eulerAngles.z + RotationDelta); ;
            GamePiece.IsRotating = false;
            StartCoroutine(LerpRotateOverTime(GamePiece.TrianglePieceObject, GamePiece, _Speed));

        }
    }

}

[System.Serializable]
public class PieceData
{
    public Vector3 CurrentPosition;
    public Vector3 NewPosition;
    public bool IsMoving;

    public Quaternion CurrentRotation;
    public Quaternion NewRotation;
    public float RotateAmount;
    public bool IsRotating;

    public GameObject TrianglePieceObject;
    public PieceData()
    {
        IsMoving = false;
        IsRotating = false;
    }

    public PieceData(GameObject a_TrianglePieceObject)
    {
        CurrentPosition = a_TrianglePieceObject.transform.position;
        IsMoving = false;
        CurrentRotation = a_TrianglePieceObject.transform.rotation;
        IsRotating = false;
        TrianglePieceObject = a_TrianglePieceObject;
    }


}
