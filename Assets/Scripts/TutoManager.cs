using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoManager : MonoBehaviour
{
    public GameObject tuto;

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
               Time.timeScale = 0;
               tuto.SetActive(true);
            }

    public void TutoEnd ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}


