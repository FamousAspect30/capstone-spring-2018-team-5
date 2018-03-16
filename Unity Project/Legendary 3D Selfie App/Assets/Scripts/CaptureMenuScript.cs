using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptureMenuScript : MonoBehaviour {

    private ManagerScript manager;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
	}
	
    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }
	
}
