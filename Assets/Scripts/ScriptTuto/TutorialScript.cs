using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {
    public GameObject player;

    public GameObject moveTutorial;
    public GameObject grabTutorial;

    public GameObject stockTutorial;
    public GameObject throwTutorial;

    private bool moveBool = false;
    private bool grabBool = false;

    private bool stockBool = false;
    private bool throwBool = false;

    // Use this for initialization
    void Start () // LANCE LE LAYOUT DEPLACEMENTS
    {
        moveBool = true;
        moveTutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update ()
    {

                // DEBUT LISTE JOYSTICKS
                // Joueur 1
                float j1AxisV = Input.GetAxis("J1Vertical");
                float j1AxisH = Input.GetAxis("J1Horizontal");

                // Joueur 2
                float j2AxisV = Input.GetAxis("J2Vertical");
                float j2AxisH = Input.GetAxis("J2Horizontal");

                // Joueur 3
                float j3AxisV = Input.GetAxis("J3Vertical");
                float j3AxisH = Input.GetAxis("J3Horizontal");

                //Joueur 4
                float j4AxisV = Input.GetAxis("J4Vertical");
                float j4AxisH = Input.GetAxis("J4Horizontal");
                // FIN LISTE JOYSTICKS


        //DEBUT LISTE TRIGGERS
        //Joueur 1
        float j1AxisRT = Input.GetAxis("J1RightTrigger");
        float j1AxisLT = Input.GetAxis("J1LeftTrigger");

        //Joueur 2
        float j2AxisRT = Input.GetAxis("J2RightTrigger");
        float j2AxisLT = Input.GetAxis("J2LeftTrigger");

        //Joueur 3
        float j3AxisRT = Input.GetAxis("J3RightTrigger");
        float j3AxisLT = Input.GetAxis("J3LeftTrigger");

        //Joueur 4
        float j4AxisRT = Input.GetAxis("J4RightTrigger");
        float j4AxisLT = Input.GetAxis("J4LeftTrigger");
        //FIN LISTE TRIGGERS


        if (moveBool == true && (j1AxisH < 0 || j1AxisH > 0 || j1AxisV < 0 || j1AxisV > 0))
        {
                ActivateGrabLayout();               
        }

        if (j1AxisRT > 0 && grabBool == true)
        {
                ActivateThrowLayout();
        }

        if ((j1AxisRT > 0 && j1AxisLT > 0) && throwBool == true)
        {
                ActivateStockLayout();
        }

    }

    void OnTriggerEnter( Collider theCollision )
    {

        

        //if (grabTutorial == true && theCollision.gameObject.tag == "Item")
        //{
            
        //}
    }

    public void ActivateGrabLayout() // LANCE LE LAYOUT GRAB
    {
        //StartCoroutine(activateGrabLayout());
        moveTutorial.SetActive(false);
        new WaitForSeconds(2);
        moveBool = false;
        grabTutorial.SetActive(true);
        grabBool = true;
    }

    public void ActivateThrowLayout() // LANCE LE LAYOUT JETER
    {
        //StartCoroutine(activateStockLayout());
        grabTutorial.SetActive(false);
        new WaitForSeconds(2);
        grabBool = false;
        throwTutorial.SetActive(true);
        throwBool = true;
    }

    public void ActivateStockLayout() // LANCE LE LAYOUT RANGER
    {
        //StartCoroutine(activateThrowLayout());
        throwTutorial.SetActive(false);
        new WaitForSeconds(2);
        throwBool = false;
        stockBool = true;
    }

}
