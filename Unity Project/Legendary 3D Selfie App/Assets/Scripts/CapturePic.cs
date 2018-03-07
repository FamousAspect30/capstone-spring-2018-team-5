using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.IO;
using UnityEngine.SceneManagement;

public class CapturePic : MonoBehaviour {
    
    private string tempPath;
    private string savePath;
    private static int picCounter;
    private WebCamTexture webCam;

    private ManagerScript manager;

    private void Start()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();

        tempPath = Application.temporaryCachePath;                      //path to save files in the temporary cache folder on the device
        savePath = "/storage/emulated/0/DCIM/Camera";                   //this is the actual path to save to the Camera roll
        picCounter = 0;
        GameObject obj = GameObject.Find("ARCamera");                   //Find the ARCamera Object within Unity, which contains the script we're looking for.
        webCam = obj.GetComponent<PhoneCamera>().selectedCamera;        //Set this.webCam to the 'selectedCamera' WebCamTexture.
    }

    private void TakeSnapShot()
    {
        Texture2D tex = new Texture2D(webCam.width, webCam.height);
        manager.setSnap(tex);
        //snap.SetPixels(webCam.GetPixels());
        //snap.Apply();

        //File.WriteAllBytes(Application.dataPath + "/Textures/BGSnap" + picCounter.ToString(), snap.EncodeToJPG());
        //File.WriteAllBytes(tempName + picCounter.ToString() + ".png", snap.EncodeToPNG());
        //File.WriteAllBytes(savePath + "/pic" + picCounter.ToString() + ".jpg", snap.EncodeToJPG());
        manager.incrementCounter();
        manager.showToastOnUiThread(manager.getPicCounter().ToString());
    }

    public void Capture ()
    {
        TakeSnapShot();
        manager.LoadNextScene(SceneManager.GetActiveScene());
	}

    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }
}