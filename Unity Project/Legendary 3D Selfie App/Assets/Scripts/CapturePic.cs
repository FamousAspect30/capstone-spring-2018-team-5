using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System.IO;

public class CapturePic : MonoBehaviour {
    
    private string tempName;
    private int picCounter;
    private WebCamTexture webCam;

    private void Start()
    {
        tempName = Application.temporaryCachePath + "/pic";
        picCounter = 0;
        GameObject obj = GameObject.Find("ARCamera");                   //Find the ARCamera Object within Unity, which contains the script we're looking for.
        webCam = obj.GetComponent<PhoneCamera>().selectedCamera;        //Set this.webCam to the 'selectedCamera' WebCamTexture.
    }

    private void TakeSnapShot()
    {
        Texture2D snap = new Texture2D(webCam.width, webCam.height);
        snap.SetPixels(webCam.GetPixels());
        snap.Apply();

        File.WriteAllBytes(tempName + picCounter.ToString() + ".png", snap.EncodeToPNG());
        picCounter++;
    }

    public void Capture ()
    {
        TakeSnapShot();
        SceneManager.LoadScene("Save Screen");
	}

    public void LoadPreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
            Debug.Log("There is no previous Scene!");
    }

}