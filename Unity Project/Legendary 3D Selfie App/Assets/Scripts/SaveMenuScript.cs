using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveMenuScript : MonoBehaviour {

    private ManagerScript manager;
    private Image bgImg;
    private Sprite bgSprite;
    private Rect rect;
	private Texture2D picture;
	string savePath;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
        bgImg = GameObject.Find("Background").GetComponent<Image>();
        rect = new Rect(0f, 0f, Screen.width, Screen.height);
        bgSprite = Sprite.Create(manager.snapShotTex, rect, new Vector2(0f, 0f));
        bgImg.sprite = bgSprite;
	}
	
    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }

	public void SavePhoto()
	{
		manager.showToastOnUiThread (Application.persistentDataPath);
		File.WriteAllBytes(savePath + System.DateTime.Now.ToString() + ".jpg", picture.EncodeToJPG());
	}

}
