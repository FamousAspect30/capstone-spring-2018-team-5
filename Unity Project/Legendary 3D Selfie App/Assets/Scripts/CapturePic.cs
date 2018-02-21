using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class CapturePic : MonoBehaviour {

  
	public void Capture ()
    {
        ScreenCapture.CaptureScreenshot("Screenshot.png", 1); //Need to concat a timestamp to the end of the screenshot name (to do later)
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