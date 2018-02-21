using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartApp ()
    {
        SceneManager.LoadScene("Selfie Capture"); //Load next Scene in the Build Index
    }
}
