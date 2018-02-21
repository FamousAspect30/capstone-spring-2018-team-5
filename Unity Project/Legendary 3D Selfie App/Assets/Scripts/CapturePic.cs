using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class CapturePic : MonoBehaviour {

	public void Capture () {
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