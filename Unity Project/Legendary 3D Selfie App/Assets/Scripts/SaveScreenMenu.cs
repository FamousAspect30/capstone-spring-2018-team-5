using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveScreenMenu : MonoBehaviour {

    string savePath;
    public Texture2D picture;
    private Sprite sprite;
    private SpriteRenderer sr;
    private ManagerScript manager;
    private RawImage background;

    private void Start()
    {
        manager = GameObject.Find("GameManagerObject").GetComponent<ManagerScript>();
        background.texture = manager.getSnap();

        savePath = "/Internal Storage/DCIM/Camera";
        //GameObject obj = GameObject.Find("Canvas");
        //picture = obj.GetComponent<CapturePic>().snap;
       // sprite = Sprite.Create(picture, new Rect(0f, 0f, picture.width, picture.height), new Vector2(0.5f, 0.5f), 100.0f);
        //obj.GetComponent<SpriteRen>
    }

    public void SavePhoto()
    {
        File.WriteAllBytes(savePath + System.DateTime.Now.ToString() + ".jpg", picture.EncodeToJPG());
    }

    public void Back()
    {
        manager.LoadPreviousScene(SceneManager.GetActiveScene());
    }
}
