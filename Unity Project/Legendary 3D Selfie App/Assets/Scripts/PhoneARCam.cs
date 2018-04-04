using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Vuforia;


public class PhoneARCam : MonoBehaviour {

    private string savePath;
    private ManagerScript manager;
    private CameraDevice ARCam;
    private Image img;
	private Image.PIXEL_FORMAT format1, format2;
	bool validFormat;

	void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
        savePath = "/storage/emulated/0/DCIM/Camera";
        ARCam = CameraDevice.Instance;
		format1 = Image.PIXEL_FORMAT.RGB888;
		format2 = Image.PIXEL_FORMAT.RGB565;
		validFormat = ARCam.SetFrameFormat (format1, true);
	}

    public void CapturePic()
    {
		if (validFormat) 		//first attempted format is valid, so getImage using format1
		{
			img = ARCam.GetCameraImage (format1);
		}
		else 					//otherwise, attempt using format2 and getImage again
		{
			ARCam.SetFrameFormat (format1, false);
			ARCam.SetFrameFormat (format2, true);
			img = ARCam.GetCameraImage (format2);
		}
			
		img.CopyToTexture(manager.snapShotTex);
        manager.showToastOnUiThread("Image copied to Manager.Texture2D");
        //manager.showToastOnUiThread("Screenshot Save to: " + savePath);
        manager.LoadNextScene(SceneManager.GetActiveScene());
    }

	public void switchCam()
	{
		if (ARCam.GetCameraDirection() == Vuforia.CameraDevice.CameraDirection.CAMERA_BACK)
		{
			ARCam.Stop();
			ARCam.Deinit();
			ARCam.Init(Vuforia.CameraDevice.CameraDirection.CAMERA_FRONT);
			ARCam.Start();
		}
		else
		{
			ARCam.Stop();
			ARCam.Deinit();
			ARCam.Init(Vuforia.CameraDevice.CameraDirection.CAMERA_BACK);
			ARCam.Start();
		}
	}
}
