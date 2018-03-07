using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private ManagerScript manager;
    
    // Use this for initialization
	void Start ()
    { 
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
    }
	
    public void StartGame()
    {
        manager.LoadNextScene(SceneManager.GetActiveScene());
    }
}
