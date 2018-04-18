using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CaptureMenuScript : MonoBehaviour {

    private ManagerScript manager;
	private PhoneARCam ARScript;
	string savePath;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
		ARScript = GameObject.Find("ARCamera").GetComponent<PhoneARCam>();
		string savePath = Application.temporaryCachePath;
	}
	
    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }

	public void Capture()
	{
		//Calls the capture method on the ARCam object.
		ARScript.CapturePic ();
		//manager.LoadNextScene (SceneManager.GetActiveScene ());
	}
}
