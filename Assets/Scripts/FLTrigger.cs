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
        if( collision.gameObject.CompareTag("FL"))
        {
            PlayerManager player = gameObject.GetComponentInParent<PlayerManager>();
            player.grabbedObjectActive = collision.gameObject;
            return;
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
           PlayerManager player = gameObject.GetComponentInParent<PlayerManager>();
            player.Ennemy = collision.gameObject;
            return;
        }

    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager player = gameObject.GetComponentInParent<PlayerManager>();
            player.Ennemy = null;

        }
    }

}