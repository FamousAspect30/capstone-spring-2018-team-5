using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartApp ()
    {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
		if(currentSceneIndex<SceneManager.sceneCount-1)
		{
			SceneManager.LoadScene(currentSceneIndex + 1);
		}
        //SceneManager.LoadScene("Selfie Capture"); //Load next Scene in the Build Index
    }
}
