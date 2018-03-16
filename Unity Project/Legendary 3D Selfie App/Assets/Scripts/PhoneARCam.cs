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
	private Image.PIXEL_FORMAT mPix;

	void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
        savePath = "/storage/emulated/0/DCIM/Camera";
        ARCam = CameraDevice.Instance;
		mPix = Image.PIXEL_FORMAT.RGB565;
	}

    public void CapturePic()
    {
		//if (ARCam.SetFrameFormat (mPix, true)) {
			img = ARCam.GetCameraImage (mPix);
		//}
		//manager.showToastOnUiThread("Image Captured");
		img.CopyToTexture(manager.snapShotTex);
        //manager.showToastOnUiThread("Image copied to Manager.Texture2D");
        //manager.showToastOnUiThread("Screenshot Save to: " + savePath);
        manager.LoadNextScene(SceneManager.GetActiveScene());
    }

}
