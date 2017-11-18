using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLTrigger : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter(Collider collision)
    {
        
            PlayerManager.Instance.grabbedObjectActive = collision.gameObject;

    }

    public void OnTriggerExit(Collider collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player.isGrabbed == false)
        {
            if (player.faceCollider)
            {
                player.grabbedObjectActive = null;
            }
        }
        
    }
}