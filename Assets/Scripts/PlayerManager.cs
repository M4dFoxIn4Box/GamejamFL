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
    public string moveHorizontal, moveVertical, grabButton;
    public GameObject Ennemy;

    public bool isGrabbed = false;
    public bool canPunch = false;
 

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 playerDirection;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void Grab()
    {
        if (grabbedObjectActive != null && Input.GetButtonDown(grabButton) && isGrabbed == false)
        {
            Rigidbody grabbedRigidbody = grabbedObjectActive.GetComponent<Rigidbody>();
            grabbedRigidbody.useGravity = false;
            grabbedRigidbody.isKinematic = true;
            grabbedObjectActive.transform.rotation = Quaternion.Euler(0, 0, 0);
            grabbedObjectActive.transform.position = grabbedPlace.transform.position;
            grabbedObjectActive.transform.parent = gameObject.transform;
            isGrabbed = true;
            return;
        }

        if (isGrabbed == true && Input.GetButtonDown(grabButton))
        {
            Rigidbody grabbedRigidbody = grabbedObjectActive.GetComponent<Rigidbody>();
            grabbedRigidbody.useGravity = true;
            grabbedRigidbody.isKinematic = false;
            grabbedObjectActive.transform.parent = null;
            if (canPunch == false)
            {
                grabbedRigidbody.AddForce(gameObject.transform.forward * 1000);
            }
            if (canPunch == true)
            {
                grabbedRigidbody.AddForce(gameObject.transform.forward * -1000);
                canPunch = false;
            }
            isGrabbed = false;
            grabbedObjectActive = null;
        }

    }
        public void PunchedGrab(GameObject ennemy)
    {
        
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
        myRigidbody.AddForce(ennemy.transform.forward * 5000);

    }


    public void Punch()
    {
        PlayerManager ennemyManager = Ennemy.GetComponentInParent<PlayerManager>();
        if (ennemyManager.isGrabbed == true && Input.GetButtonDown(grabButton) && Ennemy != null)
        {
            ennemyManager.PunchedGrab(gameObject);
            return;

        }
        if (ennemyManager.isGrabbed == false && Input.GetButtonDown(grabButton) && Ennemy != null)
        {
            ennemyManager.Punched(gameObject);

        }
    }


    
}
 