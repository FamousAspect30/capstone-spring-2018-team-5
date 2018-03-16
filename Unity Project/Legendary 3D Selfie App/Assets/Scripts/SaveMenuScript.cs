using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveMenuScript : MonoBehaviour {

    private ManagerScript manager;
    private Image bgImg;
    private Sprite bgSprite;
    private Rect rect;

    void Start ()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
        bgImg = GameObject.Find("Background").GetComponent<Image>();
        rect = new Rect(0, 0, manager.snapShotTex.width, manager.snapShotTex.height);
        bgSprite = Sprite.Create(manager.snapShotTex, rect, new Vector2(0.5f, 0.5f));
        bgImg.sprite = bgSprite;
	}
	
    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }
	
}
