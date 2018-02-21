using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// credit to N3K EN at https://www.youtube.com/watch?v=c6NXkZWXHnc&t=55s for the tutorial used to write this script for accessing the camera(s) on devices

public class PhoneCamera : MonoBehaviour {

    private bool camAvailable;
    private WebCamTexture selectedCamera;
    private WebCamTexture frontCam;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    private int screenCapNumber = 00;

    public RawImage background;
    public AspectRatioFitter fit;

    private void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for(int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }

            if (devices[i].isFrontFacing)
            {
                frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to detect rear-facing camera.");
            return;
        }

        if (frontCam == null)
        {
            Debug.Log("Unable to detect front-facing camera.");
            return;
        }

        selectedCamera = backCam;
        backCam.Play();
        background.texture = selectedCamera;

        camAvailable = true;

    }

    private void Update()
    {
        if (!camAvailable)
            return;

        float ratio = (float)frontCam.width / (float)frontCam.height;
        fit.aspectRatio = ratio;

        float scaleY = frontCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -selectedCamera.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    public void SwitchCamera()
    {
        if (selectedCamera == backCam)
        {
            backCam.Stop();
            selectedCamera = frontCam;
            frontCam.Play();
            background.texture = frontCam;
        }
        else
        {
            frontCam.Stop();
            selectedCamera = backCam;
            backCam.Play();
            background.texture = backCam;
        }
    }
}
