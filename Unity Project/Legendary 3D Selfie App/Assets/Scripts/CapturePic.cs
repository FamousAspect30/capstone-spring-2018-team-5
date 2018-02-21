using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class CapturePic : MonoBehaviour {

	public void Capture () {
		SceneManager.LoadScene("Save Screen");
	}

}