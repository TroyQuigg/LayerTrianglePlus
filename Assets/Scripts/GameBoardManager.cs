using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TrianglePieceManager;
using System.Linq;

public class GameBoardManager : MonoBehaviour
{

    [SerializeField] private GameObject[] GamePieces;
    [SerializeField] private PieceData[] GamePiecesData;

    private float RotationDelta;
    private float DeltaX;
    private float DeltaY;



    // Start is called before the first frame update
    void Start()
    {

        RotationDelta = 120f;

        DeltaX = 10f;
        DeltaY = 10f;

        int index = 0;

        GamePiecesData = new PieceData[GamePieces.Length];
   
        index = 0;
        foreach (GameObject GamePiece in GamePieces)
        {
            float _Speed = UnityEngine.Random.Range(1, 5);

            GamePiece.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
            GamePiece.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
            GamePiece.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
            GamePiece.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
            GamePiece.GetComponent<TrianglePieceManager>().OutlineOff();
            GamePiece.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
            GamePiece.GetComponent<TrianglePieceManager>().GlowOn();

            GamePiecesData[index] = new PieceData();

            GamePiecesData[index].CurrentPosition = GamePiece.transform.position;
            GamePiecesData[index].NewPosition = new Vector3(GamePiece.transform.position.x + DeltaX, GamePiece.transform.position.y + DeltaY, GamePiece.transform.position.z);
            GamePiecesData[index].IsMoving = false;
            StartCoroutine(LerpMoveOverTime(GamePiece, GamePiecesData[index], _Speed));

            GamePiecesData[index].CurrentRotation = GamePiece.transform.rotation;
            GamePiecesData[index].NewRotation = Quaternion.Euler(0, 0, GamePiece.transform.rotation.eulerAngles.z + RotationDelta); ;
            GamePiecesData[index].IsRotating = false;
            StartCoroutine(LerpRotateOverTime(GamePiece, GamePiecesData[index], _Speed));

            index++;
        }

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

    }
}
