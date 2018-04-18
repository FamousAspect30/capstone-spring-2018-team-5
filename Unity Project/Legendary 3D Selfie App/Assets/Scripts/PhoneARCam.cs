using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Vuforia;


public class PhoneARCam : MonoBehaviour {

    private ManagerScript manager;
    public CameraDevice ARCam;
	GameObject ui;
	Texture2D pic;
	bool grab = true;
	string savePath;
	int picCounter = 00;

	void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
        ARCam = CameraDevice.Instance;
		ui = GameObject.Find ("Canvas");
		pic = new Texture2D (Screen.width, Screen.height);
		savePath = Application.temporaryCachePath;
	}

    public void CapturePic()
	{
		//Sets grab to true so the OnPostRender() method knows to capture the screenshot.
		grab = true;
		return;
    }

	public void switchCam()
	{
		if (ARCam.GetCameraDirection() == Vuforia.CameraDevice.CameraDirection.CAMERA_FRONT)
		{
			ARCam.Stop();
			ARCam.Deinit();
			ARCam.Init(Vuforia.CameraDevice.CameraDirection.CAMERA_BACK);
			ARCam.Start();
		}
		else if (ARCam.GetCameraDirection() == Vuforia.CameraDevice.CameraDirection.CAMERA_BACK)
		{
			ARCam.Stop();
			ARCam.Deinit();
			ARCam.Init(Vuforia.CameraDevice.CameraDirection.CAMERA_FRONT);
			ARCam.Start();
		}
	}

	private void OnPostRender()
	{
		if (grab) {
			//First hide the UI elements.
			ui.SetActiveRecursively (false);
			//Then create the texture to hold the screenshot.
			Texture2D pic = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
			//Read all of the pixels in the Rect starting at the corner and going to the full screen height and width.
			pic.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0, false);
			//Draw pixels to the texture.
			pic.Apply ();
			//Save the texture as a picture on the device at a given filepath.
			File.WriteAllBytes (savePath + "/pic" + manager.getPicCounter() + ".jpg", pic.EncodeToJPG ());
			//manager.showToastOnUiThread ("Picture " + manager.getPicCounter() + " captured!");
			manager.snapShotTex = pic;
			//Reset grab, so the method only captures 1 picture.
			grab = false;
			//Increment the picCounter
			manager.incrementCounter();
			//Show the UI elements again.
			ui.SetActiveRecursively (true);
		}
	}
}
