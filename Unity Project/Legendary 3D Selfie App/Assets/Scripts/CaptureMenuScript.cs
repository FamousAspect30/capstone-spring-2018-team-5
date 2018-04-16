using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class CaptureMenuScript : MonoBehaviour {

    private ManagerScript manager;
	private PhoneARCam ARScript;
	GameObject ui;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
		ARScript = GameObject.Find("ARCamera").GetComponent<PhoneARCam>();
	}
	
    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }

	public void Capture()
	{
		ARScript.CapturePic();
		//ARScript.ARCam.Stop();
		//manager.LoadNextScene(SceneManager.GetActiveScene());

		//OLD METHOD
		//snap = new Texture2D(webCam.width, webCam.height);
		//snap.SetPixels(webCam.GetPixels());
		//snap.Apply();

		//showToastOnUiThread(savePath);

		//File.WriteAllBytes(Application.dataPath + "/Textures/BGSnap" + picCounter.ToString(), snap.EncodeToJPG());
		//File.WriteAllBytes(tempName + picCounter.ToString() + ".png", snap.EncodeToPNG());
		//File.WriteAllBytes(savePath + "/pic" + picCounter.ToString() + ".jpg", snap.EncodeToJPG());
		//picCounter++;
	}

	/*
	public void switchCam()
	{
		Vuforia.CameraDevice.CameraDirection currentDir = Vuforia.CameraDevice.Instance.GetCameraDirection();
		if (!cameramode)
		{
			RestartCamera(Vuforia.CameraDevice.CameraDirection.CAMERA_FRONT);
			Debug.Log("Using FRONT Camera");
			cameramode = true;
		}
		else
		{
			RestartCamera(Vuforia.CameraDevice.CameraDirection.CAMERA_BACK);
			Debug.Log("Using BACK Camera");
			cameramode = false;
		}
	}

	private void RestartCamera(Vuforia.CameraDevice.CameraDirection newDir)
	{
		Vuforia.CameraDevice.Instance.Stop();
		Vuforia.CameraDevice.Instance.Deinit();
		Vuforia.CameraDevice.Instance.Init(newDir);
		Vuforia.CameraDevice.Instance.Start();
	}
	*/
}
