using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptureMenuScript : MonoBehaviour {

    private ManagerScript manager;
	private PhoneARCam ARScript;
	string savePath;
	int heroNum;
	SpriteRenderer fireHero;
	SpriteRenderer waterHero;
	SpriteRenderer earthHero;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
		ARScript = GameObject.Find("ARCamera").GetComponent<PhoneARCam>();
		fireHero = GameObject.Find ("Fire Champion").GetComponent<SpriteRenderer>();
		waterHero = GameObject.Find ("Water Champion").GetComponent<SpriteRenderer>();
		earthHero = GameObject.Find ("Earth Champion").GetComponent<SpriteRenderer>();
		string savePath = Application.temporaryCachePath;
		heroNum = 1;
	}

	public void Update()
	{
		if (heroNum == 1) 
		{
			fireHero.enabled = true;
			waterHero.enabled = false;
			earthHero.enabled = false;
		}

		else if (heroNum == 2) 
		{
			fireHero.enabled = false;
			waterHero.enabled = true;
			earthHero.enabled = false;
		} 

		else if (heroNum == 3) 
		{
			fireHero.enabled = false;
			waterHero.enabled = false;
			earthHero.enabled = true;
		}
	}
	
    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }

	public void Capture()
	{
		//Calls the capture method on the ARCam object.
		ARScript.CapturePic ();
		manager.showToastOnUiThread ("Picture Captured!");
	}


	public void SwapHero()
	{
		if (heroNum == 1)
			heroNum = 2;
		else if (heroNum == 2)
			heroNum = 3;
		else if (heroNum == 3)
			heroNum = 1;
	}
}
