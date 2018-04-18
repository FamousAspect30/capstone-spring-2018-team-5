using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour {

	private ManagerScript manager;
	string savePath;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();	
		savePath = Application.temporaryCachePath;
	}

    public void StartGame()
    {
		//smanager.showToastOnUiThread (savePath);
        manager.LoadNextScene(SceneManager.GetActiveScene());
    }
}
