using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void LoadNextScene ()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        //if(currentSceneIndex<SceneManager.sceneCount-1)
        //{
        //	SceneManager.LoadScene(currentSceneIndex + 1);
        //}

        Debug.Log("You're in the LoadNextScene() Funcition!!");

        SceneManager.LoadScene("Selfie Capture");
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
