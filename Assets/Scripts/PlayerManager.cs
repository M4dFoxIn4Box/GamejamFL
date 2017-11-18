using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance { get; private set; }

    public Collider faceCollider;
    public GameObject grabbedPlace;
    public GameObject grabbedObjectActive;
    public float moveSpeed;
    private Rigidbody myRigidbody;

    public bool isGrabbed = false;
 

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 playerDirection;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        playerDirection = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }
        Grab();
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    private void Grab()
    {
        if (grabbedObjectActive != null && Input.GetButtonDown("Fire1") && isGrabbed == false)
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
        if (isGrabbed == true && Input.GetButtonDown("Fire1"))
        {
            Rigidbody grabbedRigidbody = grabbedObjectActive.GetComponent<Rigidbody>();
            grabbedRigidbody.useGravity = true;
            grabbedRigidbody.isKinematic = false;
            grabbedObjectActive.transform.parent = null;
            grabbedRigidbody.AddForce(gameObject.transform.forward * 1000);
            isGrabbed = false;

        }
    }


    
}
 