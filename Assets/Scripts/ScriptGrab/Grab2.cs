using System.Collections ;
using System.Collections.Generic ;
using UnityEngine ;

public class Grab2 : MonoBehaviour 
{
	public Transform player ;
	public Transform playerCam ;
	public float throwForce = 10 ;
	private bool hasPlayer = false ;
	private bool beingCarried = false ;
	public AudioClip[] soundtoPlay ;
	public int dmg ;
	private bool touched = false ;



void Update()
{
	float dist = Vector3.Distance(gameObject.transform.position, player.position) ;
	if (dist <= 2.5f)
	{
		hasPlayer = true;
	}
	else 
	{
		hasPlayer = false;
	}
	if (hasPlayer && Input.GetButtonDown("Fire1") && !beingCarried)
	{
		GetComponent<Rigidbody>().isKinematic = true ;
		transform.parent = playerCam ;
            beingCarried = true ;
            return;
	}
	if (beingCarried)
	{
		if (touched)
		{
			GetComponent<Rigidbody>().isKinematic = false ;
			transform.parent = null ;
			beingCarried = false ;
			touched = false ;
		}
		if (Input.GetButtonDown("Fire1"))
		{
			GetComponent<Rigidbody>().isKinematic = false ;
			transform.parent = null ; 
			beingCarried = false ;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce) ;
		}
		else if (Input.GetMouseButtonDown(1))
		{
			GetComponent<Rigidbody>().isKinematic = false ;
				transform.parent = null ;
			beingCarried = false ;
		}
	}
}

void RandomAudio()
{
	if (GetComponent<AudioSource>().isPlaying)
	{
		GetComponent<AudioSource>().clip = soundtoPlay[Random.Range(0, soundtoPlay.Length)] ;
		GetComponent<AudioSource>().Play() ;
	}
}

void OnTriggerEnter()
{
	if (beingCarried)
	{
		touched = true;
	}
}
}