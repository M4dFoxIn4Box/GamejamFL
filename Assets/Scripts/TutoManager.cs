using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutoManager : MonoBehaviour
{
    public GameObject tuto;
    public GameObject tutoButton;
    


    // Use this for initialization
    void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update () 
        {
       
        }

	public void TutoLaunch ()
            {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        Time.timeScale = 0;
        tuto.SetActive(true);           
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(tutoButton);
    }

    public void TutoEnd ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}


