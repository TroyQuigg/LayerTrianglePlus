using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TrianglePieceManager;

public class GameBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject GamePiece_A01;
    [SerializeField] private GameObject GamePiece_A02;
    [SerializeField] private GameObject GamePiece_A03;
    [SerializeField] private GameObject GamePiece_A04;
    [SerializeField] private GameObject GamePiece_B01;
    [SerializeField] private GameObject GamePiece_B02;
    [SerializeField] private GameObject GamePiece_B03;
    [SerializeField] private GameObject GamePiece_B04;

    private Quaternion A01_Rotation;
    private Quaternion A02_Rotation;
    private Quaternion A03_Rotation;
    private Quaternion A04_Rotation;
    private Quaternion B01_Rotation;
    private Quaternion B02_Rotation;
    private Quaternion B03_Rotation;
    private Quaternion B04_Rotation;

    //private float A01_StartRotation;
    //private float A02_StartRotation;
    //private float A03_StartRotation;
    //private float A04_StartRotation;
    //private float B01_StartRotation;
    //private float B02_StartRotation;
    //private float B03_StartRotation;
    //private float B04_StartRotation;


    private float RotationSpeed;
    private float RotationDelta;

    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = 3;
        RotationDelta = 60f;
        //A01_StartRotation = GamePiece_A01.transform.rotation.z;
        //A02_StartRotation = GamePiece_A02.transform.rotation.z;
        //A03_StartRotation = GamePiece_A03.transform.rotation.z;
        //A04_StartRotation = GamePiece_A04.transform.rotation.z;
        //B01_StartRotation = GamePiece_B01.transform.rotation.z;
        //B02_StartRotation = GamePiece_B02.transform.rotation.z;
        //B03_StartRotation = GamePiece_B03.transform.rotation.z;
        //B04_StartRotation = GamePiece_B04.transform.rotation.z;

        A01_Rotation = GamePiece_A01.transform.rotation;
        A02_Rotation = GamePiece_A02.transform.rotation;
        A03_Rotation = GamePiece_A03.transform.rotation;
        A04_Rotation = GamePiece_A04.transform.rotation;
        B01_Rotation = GamePiece_B01.transform.rotation;
        B02_Rotation = GamePiece_B02.transform.rotation;
        B03_Rotation = GamePiece_B03.transform.rotation;
        B04_Rotation = GamePiece_B04.transform.rotation;

        GamePiece_A01.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_A01.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_A01.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_A01.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_A01.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_A01.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_A01.GetComponent<TrianglePieceManager>().GlowOn();
    
        GamePiece_A02.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_A02.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_A02.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_A02.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_A02.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_A02.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_A02.GetComponent<TrianglePieceManager>().GlowOn();

        GamePiece_A03.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_A03.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_A03.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_A03.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_A03.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_A03.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_A03.GetComponent<TrianglePieceManager>().GlowOn();

        GamePiece_A04.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_A04.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_A04.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_A04.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_A04.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_A04.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_A04.GetComponent<TrianglePieceManager>().GlowOn();

        GamePiece_B01.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_B01.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_B01.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_B01.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_B01.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_B01.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_B01.GetComponent<TrianglePieceManager>().GlowOn();

        GamePiece_B02.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_B02.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_B02.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_B02.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_B02.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_B02.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_B02.GetComponent<TrianglePieceManager>().GlowOn();

        GamePiece_B03.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_B03.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_B03.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_B03.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_B03.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_B03.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_B03.GetComponent<TrianglePieceManager>().GlowOn();

        GamePiece_B04.GetComponent<TrianglePieceManager>().SetPieceType(GetRandomPieceType());
        GamePiece_B04.GetComponent<TrianglePieceManager>().SetPieceColors(GetRandomPieceColor(), GetRandomPieceColor(), GetRandomPieceColor());
        GamePiece_B04.GetComponent<TrianglePieceManager>().SetBackgroundColors(PieceColor.Black);
        GamePiece_B04.GetComponent<TrianglePieceManager>().SetOutlineColor(PieceColor.Black);
        GamePiece_B04.GetComponent<TrianglePieceManager>().OutlineOff();
        GamePiece_B04.GetComponent<TrianglePieceManager>().SetGlowColor(GetRandomPieceColor());
        GamePiece_B04.GetComponent<TrianglePieceManager>().GlowOn();

    }

    // Update is called once per frame
    void Update()
    {
        GamePiece_A01.transform.position = new Vector3(GamePiece_A01.transform.position.x + (.3f) * Time.deltaTime, GamePiece_A01.transform.position.y, GamePiece_A01.transform.position.z);
        GamePiece_A02.transform.position = new Vector3(GamePiece_A02.transform.position.x + (.4f) * Time.deltaTime, GamePiece_A02.transform.position.y, GamePiece_A02.transform.position.z);
        GamePiece_A03.transform.position = new Vector3(GamePiece_A03.transform.position.x + (.5f) * Time.deltaTime, GamePiece_A03.transform.position.y, GamePiece_A03.transform.position.z);
        GamePiece_A04.transform.position = new Vector3(GamePiece_A04.transform.position.x + (.6f) * Time.deltaTime, GamePiece_A04.transform.position.y, GamePiece_A04.transform.position.z);
        GamePiece_B01.transform.position = new Vector3(GamePiece_B01.transform.position.x + (.7f) * Time.deltaTime, GamePiece_B01.transform.position.y, GamePiece_B01.transform.position.z);
        GamePiece_B02.transform.position = new Vector3(GamePiece_B02.transform.position.x + (.8f) * Time.deltaTime, GamePiece_B02.transform.position.y, GamePiece_B02.transform.position.z);
        GamePiece_B03.transform.position = new Vector3(GamePiece_B03.transform.position.x + (.9f) * Time.deltaTime, GamePiece_B03.transform.position.y, GamePiece_B03.transform.position.z);
        GamePiece_B04.transform.position = new Vector3(GamePiece_B04.transform.position.x + (.2f) * Time.deltaTime, GamePiece_B04.transform.position.y, GamePiece_B04.transform.position.z);

        A01_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_A01.transform.forward);
        A02_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_A02.transform.forward);
        A03_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_A03.transform.forward);
        A04_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_A04.transform.forward);
        B01_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_B01.transform.forward);
        B02_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_B02.transform.forward);
        B03_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_B03.transform.forward);
        B04_Rotation = Quaternion.AngleAxis(RotationDelta, GamePiece_B04.transform.forward);
        //A02_Rotation = Quaternion.AngleAxis(60, GamePiece_A02.transform.forward);
        //A03_Rotation = Quaternion.AngleAxis(60, GamePiece_A03.transform.forward);
        //A04_Rotation = Quaternion.AngleAxis(60, GamePiece_A04.transform.forward);
        //B01_Rotation = Quaternion.AngleAxis(-60, GamePiece_B01.transform.forward);
        //B02_Rotation = Quaternion.AngleAxis(-60, GamePiece_B02.transform.forward);
        //B03_Rotation = Quaternion.AngleAxis(-60, GamePiece_B03.transform.forward);
        //B04_Rotation = Quaternion.AngleAxis(-60, GamePiece_B04.transform.forward);

        GamePiece_A01.transform.rotation = Quaternion.Lerp(GamePiece_A01.transform.rotation, A01_Rotation, RotationSpeed * Time.deltaTime);
        GamePiece_A02.transform.rotation = Quaternion.Lerp(GamePiece_A02.transform.rotation, A02_Rotation, RotationSpeed * Time.deltaTime);
        GamePiece_A03.transform.rotation = Quaternion.Lerp(GamePiece_A03.transform.rotation, A03_Rotation, RotationSpeed * Time.deltaTime);
        GamePiece_A04.transform.rotation = Quaternion.Lerp(GamePiece_A04.transform.rotation, A04_Rotation, RotationSpeed * Time.deltaTime);
        GamePiece_B01.transform.rotation = Quaternion.Lerp(GamePiece_B01.transform.rotation, B01_Rotation, RotationSpeed * Time.deltaTime);
        GamePiece_B02.transform.rotation = Quaternion.Lerp(GamePiece_B02.transform.rotation, B02_Rotation, RotationSpeed * Time.deltaTime);
        GamePiece_B03.transform.rotation = Quaternion.Lerp(GamePiece_B03.transform.rotation, B03_Rotation, RotationSpeed * Time.deltaTime);
        GamePiece_B04.transform.rotation = Quaternion.Lerp(GamePiece_B04.transform.rotation, B04_Rotation, RotationSpeed * Time.deltaTime);



    }

    private PieceColor GetRandomPieceColor()
    {
        Array _EnumValues = Enum.GetValues(typeof(PieceColor));
        int _RandomIndex = UnityEngine.Random.Range(2, _EnumValues.Length);
        PieceColor _RandomPieceColor = (PieceColor)_EnumValues.GetValue(_RandomIndex);

        //Debug.Log("Random Index: " + _RandomIndex);

        return _RandomPieceColor;
    }

    private PieceType GetRandomPieceType()
    {
        Array _EnumValues = Enum.GetValues(typeof(PieceType));
        int _RandomeIndex = UnityEngine.Random.Range(0, _EnumValues.Length);
        PieceType _RandomPieceType = (PieceType)_EnumValues.GetValue(_RandomeIndex);

        return _RandomPieceType;
    }
}
