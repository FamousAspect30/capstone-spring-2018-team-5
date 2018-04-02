using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class CaptureMenuScript : MonoBehaviour {

    private ManagerScript manager;
	bool cameramode = false;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
	}
	
    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }
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
}
