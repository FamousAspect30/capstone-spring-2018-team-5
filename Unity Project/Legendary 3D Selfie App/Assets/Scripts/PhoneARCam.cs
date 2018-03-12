using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class PhoneARCam : MonoBehaviour {

    private string savePath;
    private ManagerScript manager;

	void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
        savePath = "/storage/emulated/0/DCIM/Camera";
	}

    public void CapturePic()
    {
        manager.showToastOnUiThread("Screenshot Save to: " + savePath);
    }

}
