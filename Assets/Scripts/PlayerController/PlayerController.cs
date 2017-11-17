using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour {

	public float speed;

	private GameObject grabableObject = null;
	public BoxCollider grabCollider;
	private int myPlyrNmb;

	private Rigidbody playerRb;
	public GameObject playerGrabPosition;
	private float leftTrigger;
	private float rightTrigger;
	private float hAxis;
	private float vAxis;
	private bool aButtonDown;
	private bool aButtonUp;
	private bool bButton;
	private bool startButton;
	private bool isGrabbing = false;
	private Rigidbody objectGrabbedRb;
	private GameObject objectGrabbed;
	public float thrust;
	public int playerNumber;
    public GameObject stocking;
    
    private Countdown GMS;


    // Use this for initialization
    void Start () {
    	if (gameObject.CompareTag("J1") && !MenuLobby.player1InGame){
    		gameObject.SetActive(false);
    	}if (gameObject.CompareTag("J2") && !MenuLobby.player2InGame){
    		gameObject.SetActive(false);
    	}if (gameObject.CompareTag("J3") && !MenuLobby.player3InGame){
    		gameObject.SetActive(false);
    	}if (gameObject.CompareTag("J4") && !MenuLobby.player4InGame){
    		gameObject.SetActive(false);
    	}
		playerRb = GetComponent<Rigidbody>();
		myPlyrNmb = playerNumber;

		GMS = GameObject.Find ("UImanager").GetComponent<Countdown>();
		// if (gameObject.CompareTag("J"+myPlyrNmb.ToString()+"")){
		// 	playerNumber = "+myPlyrNmb.ToString()+";
		// }else if (gameObject.CompareTag("J2")){
		// 	playerNumber = 2;
		// }else if (gameObject.CompareTag("J3")){
		// 	playerNumber = 3;
		// }else if (gameObject.CompareTag("J4")){
		// 	playerNumber = 4;
		// }
	}
	
	// Update is called once per frame
	void Update () 
	{
			

		hAxis = Input.GetAxis("J"+myPlyrNmb.ToString()+"Horizontal");
		vAxis = Input.GetAxis("J"+myPlyrNmb.ToString()+"Vertical");

		aButtonDown = Input.GetButtonDown("J"+myPlyrNmb.ToString()+"A");
		aButtonUp = Input.GetButtonUp("J"+myPlyrNmb.ToString()+"A");
		bButton = Input.GetButtonDown("J"+myPlyrNmb.ToString()+"B");
		startButton = Input.GetButtonDown("J"+myPlyrNmb.ToString()+"Start");


		leftTrigger = Input.GetAxis("J"+myPlyrNmb.ToString()+"LeftTrigger");
		rightTrigger = Input.GetAxis("J"+myPlyrNmb.ToString()+"RightTrigger");

		MoveManager();
		GrabManager();

		if (startButton)
		{
			UIManagerIG.Instance().TogglePause(myPlyrNmb);
		}
	}

	void MoveManager(){
		
		if(GMS.counterDownDone)
		{
			Vector3 movement = new Vector3(hAxis, 0.0f, vAxis);
		
        	if (hAxis < 0 || hAxis >0 || vAxis < 0 || vAxis > 0)
        	{ 
			playerRb.AddForce(movement.normalized * speed, ForceMode.Impulse);
        	}

        	if (movement != Vector3.zero){
    			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.2f);
			}
		}


		// Vector3 movement = transform.TransformDirection(new Vector3(hAxis, 0f, vAxis) * speed * Time.deltaTime);
		// transform.rotation = Quaternion.LookRotation(movement);
		// transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);

		// if (aButton){
		// 	Debug.Log("A");
		// }
		// if(bButton){
		// 	Debug.Log("B");
		// }
		// if(startButton){
		// 	Debug.Log("Start" + myPlyrNmb);
		// }
		// if(hAxis != 0f){
		// 	Debug.Log("Horizontal:" + hAxis.ToString());
		// }
		// if(rightTrigger != 0f){
		// 	Debug.Log("Right Trigger value:" +  rightTrigger.ToString());
		// }
		// if(leftTrigger != 0f){
		// 	Debug.Log("Left Trigger value:" + leftTrigger.ToString());
		// }
		// if (vAxis != 0f){
		// 	Debug.Log("Vertical :" + vAxis.ToString());
		// }
	}

	void GrabManager()
    {

		

		if (aButtonDown && grabableObject != null)
        {
        	grabableObject.transform.position = playerGrabPosition.transform.position;
			grabableObject.transform.SetParent(playerGrabPosition.transform);
            objectGrabbed = grabableObject;
			isGrabbing = true;
			grabCollider.enabled = false;
			objectGrabbedRb = grabableObject.GetComponent<Rigidbody>();
			grabableObject.GetComponent<CrateManager>().SetPlayerNb(myPlyrNmb);
			objectGrabbedRb.isKinematic = true;
			objectGrabbedRb.useGravity = false;
			objectGrabbedRb.GetComponent<Collider>().enabled = false;
			AudioSource audio = GetComponent<AudioSource>();
        	audio.Play();
		}

        else if(aButtonUp && isGrabbing)
        {	
			grabableObject.transform.SetParent(null);
            objectGrabbed = null;
			objectGrabbedRb.isKinematic = false;
			objectGrabbedRb.useGravity = true;
			objectGrabbedRb.GetComponent<Collider>().enabled = true;
			objectGrabbedRb = null;
        	// grabableObject.GetComponent<CrateManager>().SetPlayerNb(0);
			grabableObject = null;
			isGrabbing = false;
			grabCollider.enabled = true;
		}
	}

	void OnTriggerEnter (Collider other)
    {
		if (other.CompareTag("Item"))
        {
        	grabableObject = other.gameObject;
        }

        // if (other.CompareTag("Container"))
        // {
        //    // if (Input.GetButtonDown("J" + myPlyrNmb.ToString() + "X"))
           
        //   // {
        //         Destroy(objectGrabbed);
        //         grabableObject.transform.SetParent(null);
        //         objectGrabbed = null;
        //         objectGrabbedRb.isKinematic = false;
        //         objectGrabbedRb.useGravity = true;
        //         objectGrabbedRb.GetComponent<Collider>().enabled = true;
        //         objectGrabbedRb = null;
        //         grabableObject = null;
        //         isGrabbing = false;
        //         grabCollider.enabled = true;
        //      // }
        // }
    }

    void OnTriggerExit (Collider other)
    {
		if (other.CompareTag("Item"))
        {
        	grabableObject = null;
        }
    }
}