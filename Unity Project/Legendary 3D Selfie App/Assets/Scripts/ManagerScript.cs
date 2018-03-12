using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class ManagerScript : MonoBehaviour {

    public static ManagerScript instance = null;
    public static int picCounter;

    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;

    private Texture2D tempSnap;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //This if statement is for getting the Toast message to appear on Androids
        if (Application.platform == RuntimePlatform.Android)
        {
            UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        }

        picCounter = 0;
    }

    public void showToastOnUiThread(string toastString)
    {
        this.toastString = toastString;
        try
        {
            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
        }
        catch (Exception e)
        {
            Debug.Log("No Toast messages on non-Android devices, silly!");
            Debug.Log(e.ToString());
        }
    }

    void showToast()
    {
        Debug.Log(this + ": Running on UI thread");

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }

    public Texture2D getSnap()
    {
        return tempSnap;
    }

    public void setSnap(Texture2D tex)
    {
        tempSnap = tex;
    }

    public int getPicCounter()
    {
        return picCounter;
    }

    public void incrementCounter()
    {
        picCounter++;
    }

    public void LoadNextScene(Scene s)
    {
        try
        {
            int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            showToastOnUiThread("Loading Scene " + nextIndex.ToString());
            SceneManager.LoadScene(s.buildIndex + 1);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            showToastOnUiThread(e.ToString());
        }
    }

    public void LoadPreviousScene(Scene s)
    {
        try
        {
            int prevIndex = SceneManager.GetActiveScene().buildIndex - 1;
            showToastOnUiThread("Loading Scene " + prevIndex.ToString());
            SceneManager.LoadScene(s.buildIndex - 1);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            showToastOnUiThread(e.ToString());
        }
    }
}
