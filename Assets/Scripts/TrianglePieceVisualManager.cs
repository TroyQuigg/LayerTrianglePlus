using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TrianglePieceVisualManager : MonoBehaviour
{
    [SerializeField] private GameObject Side0;
    [SerializeField] private GameObject Side1;
    [SerializeField] private GameObject Side2;
    [SerializeField] private GameObject Side3;


    [SerializeField] private GameObject Background0;
    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;
    [SerializeField] private GameObject Background3;

    [SerializeField] private GameObject Outline;
    [SerializeField] private GameObject GlowOutline;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ShowGlow()
    {
        GlowOutline.SetActive(true);
    }
    
    public void HideGlow()
    {
        GlowOutline.SetActive(false);
    }
    
    public void ShowOutline()
    {
        Outline.SetActive(true);
    }
    
    public void HideOutline()
    {
        Outline.SetActive(false);
    }
    
    public void SetOutlineColor(Color a_Color)
    {
        Outline.GetComponent<SpriteRenderer>().color = a_Color; ;
    }

    public void SetGlowColor(Color a_Color)
    {
        GlowOutline.GetComponent<SpriteRenderer>().color = a_Color; ;
    }

    public void SetSwirlRight()
    {
        Side0.SetActive(false);
        Side1.SetActive(true);
        Side2.SetActive(true); 
        Side3.SetActive(true);

        Background0.SetActive(false);
        Background1.SetActive(true);
        Background2.SetActive(true);
        Background3.SetActive(true);

        Side1.GetComponent<SpriteRenderer>().flipX = true;
        Side2.GetComponent<SpriteRenderer>().flipX = true;
        Side3.GetComponent<SpriteRenderer>().flipX = true;

        Background1.GetComponent<SpriteRenderer>().flipX = true;
        Background2.GetComponent<SpriteRenderer>().flipX = true;
        Background3.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void SetSwirlLeft()
    {
        Side0.SetActive(false);
        Side1.SetActive(true);
        Side2.SetActive(true);
        Side3.SetActive(true);

        Background0.SetActive(false);
        Background1.SetActive(true);
        Background2.SetActive(true);
        Background3.SetActive(true);

        Side1.GetComponent<SpriteRenderer>().flipX = false;
        Side2.GetComponent<SpriteRenderer>().flipX = false;
        Side3.GetComponent<SpriteRenderer>().flipX = false;

        Background1.GetComponent<SpriteRenderer>().flipX = false;
        Background2.GetComponent<SpriteRenderer>().flipX = false;
        Background3.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void SetRay()
    {
        Side0.SetActive(true);
        Side1.SetActive(false);
        Side2.SetActive(false);
        Side3.SetActive(false);

        Background0.SetActive(true);
        Background1.SetActive(false);
        Background2.SetActive(false);
        Background3.SetActive(false);
    }

    public void SetSideColor(int a_SideNumber, Color a_Color)
    {
        switch (a_SideNumber)
        {
            case 0:
                Side0.GetComponent<SpriteRenderer>().color = a_Color;
                break;
            case 1:
                Side1.GetComponent<SpriteRenderer>().color = a_Color;
                break;
            case 2:
                Side2.GetComponent<SpriteRenderer>().color = a_Color;
                break;
            case 3:
                Side3.GetComponent<SpriteRenderer>().color = a_Color;
                break;
        }
    }

    public void SetBackgroundColor(int a_BackgroundNumber, Color a_Color)
    {
        switch (a_BackgroundNumber)
        {
            case 0:
                Background0.GetComponent<SpriteRenderer>().color = a_Color;
                break;
            case 1:
                Background1.GetComponent<SpriteRenderer>().color = a_Color;
                break;
            case 2:
                Background2.GetComponent<SpriteRenderer>().color = a_Color;
                break;
            case 3:
                Background3.GetComponent<SpriteRenderer>().color = a_Color;
                break;
        }
    }


}
