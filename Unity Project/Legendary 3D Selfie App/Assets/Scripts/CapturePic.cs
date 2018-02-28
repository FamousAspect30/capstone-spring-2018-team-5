using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System.IO;

public class CapturePic : MonoBehaviour {

    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;

    private string tempName;
    private string savePath;    //for testing purposes
    private int picCounter;
    private WebCamTexture webCam;
    public Texture2D snap;

    private void Start()
    {
        //This if statement is for getting the Toast message to appear on Androids
        if (Application.platform == RuntimePlatform.Android)
        {
            UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        }

        tempName = Application.temporaryCachePath + "/pic";
        savePath = "/storage/emulated/0/DCIM/Camera";                   //this is the actual path to save to the Camera roll
        picCounter = 0;
        GameObject obj = GameObject.Find("ARCamera");                   //Find the ARCamera Object within Unity, which contains the script we're looking for.
        webCam = obj.GetComponent<PhoneCamera>().selectedCamera;        //Set this.webCam to the 'selectedCamera' WebCamTexture.
    }

    public void showToastOnUiThread(string toastString)
    {
        this.toastString = toastString;
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    void showToast()
    {
        Debug.Log(this + ": Running on UI thread");

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }

    private void TakeSnapShot()
    {
        snap = new Texture2D(webCam.width, webCam.height);
        snap.SetPixels(webCam.GetPixels());
        snap.Apply();

        showToastOnUiThread(savePath);

        //File.WriteAllBytes(Application.dataPath + "/Textures/BGSnap" + picCounter.ToString(), snap.EncodeToJPG());
        //File.WriteAllBytes(tempName + picCounter.ToString() + ".png", snap.EncodeToPNG());
		File.WriteAllBytes(savePath + "/pic" + picCounter.ToString() + ".jpg", snap.EncodeToJPG());
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