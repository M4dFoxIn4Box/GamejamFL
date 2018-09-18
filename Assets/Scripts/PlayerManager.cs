using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{


    public Collider faceCollider;
    public GameObject grabbedPlace;
    public GameObject grabbedObjectActive;
    public float moveSpeed;
    private Rigidbody myRigidbody;
    public GameObject showPlayer;


    public string moveHorizontal, moveVertical, grabButton, checkButton;

    public GameObject Ennemy;

    public bool isGrabbed = false;
    private bool canPunch = true;
    public Aliments.TeamType playerTeam;

    public float punchTimer;
    private float actualTimerPunch;



    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 playerDirection;

    // Use this for initialization
    void Start()
    {
        actualTimerPunch = punchTimer;
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.end == false)
        {
            ShowPlayer();
            moveInput = new Vector3(Input.GetAxisRaw(moveHorizontal), 0f, Input.GetAxisRaw(moveVertical));
            moveVelocity = moveInput * moveSpeed;

            playerDirection = Vector3.right * Input.GetAxisRaw(moveHorizontal) + Vector3.forward * Input.GetAxisRaw(moveVertical);
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
            Grab();
            Punch();
        }

        if (canPunch == false)
        {
            actualTimerPunch -= Time.deltaTime;
            if (actualTimerPunch <= 0)
            {
                canPunch = true;
                actualTimerPunch = punchTimer;
            }

        }




    }

    void ShowPlayer()
    {
        if (Input.GetButtonDown(checkButton))
        {
            showPlayer.SetActive(true);
        }
        if (Input.GetButtonUp(checkButton))
        {
            showPlayer.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void Grab()
    {
        if (grabbedObjectActive != null && Input.GetButtonDown(grabButton) && isGrabbed == false)
        {
            GameManager.Instance.PlayGrab();
            Aliments grabbedScript = grabbedObjectActive.GetComponent<Aliments>();
            grabbedScript.teamtype = playerTeam;
            Rigidbody grabbedRigidbody = grabbedObjectActive.GetComponent<Rigidbody>();
            grabbedRigidbody.useGravity = false;
            grabbedRigidbody.isKinematic = true;
            grabbedObjectActive.transform.rotation = Quaternion.Euler(0, 0, 0);
            grabbedObjectActive.transform.position = grabbedPlace.transform.position;
            grabbedObjectActive.transform.parent = gameObject.transform;
            isGrabbed = true;
            return;
        }

        if (grabbedObjectActive != null && isGrabbed == true && Input.GetButtonDown(grabButton))
        {
            GameManager.Instance.PlayLaunch();
            Rigidbody grabbedRigidbody = grabbedObjectActive.GetComponent<Rigidbody>();
            grabbedRigidbody.useGravity = true;
            grabbedRigidbody.isKinematic = false;
            grabbedObjectActive.transform.parent = null;

            grabbedRigidbody.AddForce(gameObject.transform.forward * 1000);

            isGrabbed = false;
            grabbedObjectActive = null;
            return;
        }

    }
    public void PunchedGrab(GameObject ennemy, Aliments.TeamType teamType)
    {
        GameManager.Instance.PlayPunch();
        Aliments grabbedScript = grabbedObjectActive.GetComponent<Aliments>();
        grabbedScript.teamtype = teamType;
        Rigidbody grabbedRigidbody = grabbedObjectActive.GetComponent<Rigidbody>();
        grabbedRigidbody.useGravity = true;
        grabbedRigidbody.isKinematic = false;
        grabbedObjectActive.transform.parent = null;
        grabbedRigidbody.AddForce(ennemy.transform.forward * 1000);
        isGrabbed = false;
        myRigidbody.AddForce(ennemy.transform.forward * 5000);
        grabbedObjectActive = null;

    }
    public void Punched(GameObject ennemy)
    {
        GameManager.Instance.PlayPunch();
        myRigidbody.AddForce(ennemy.transform.forward * 5000);

    }


    public void Punch()
    {
        if (Ennemy != null)
        {
            PlayerManager ennemyManager = Ennemy.GetComponentInParent<PlayerManager>();



        if (ennemyManager.isGrabbed == true && Input.GetButtonDown(grabButton) && Ennemy != null)
        {
            if (canPunch == true)
            {
                ennemyManager.PunchedGrab(gameObject, playerTeam);
                canPunch = false;
                return;

            }

        }
        if (ennemyManager.isGrabbed == false && Input.GetButtonDown(grabButton) && Ennemy != null)
        {
            if (canPunch == true)
            {
                ennemyManager.Punched(gameObject);
                canPunch = false;
            }
        }
        }

    }



}