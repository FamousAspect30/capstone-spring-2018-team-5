using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveScreenMenu : MonoBehaviour {

    string savePath;
    public Texture2D picture;
    private Sprite sprite;
    private SpriteRenderer sr;

    private void Start()
    {
        savePath = "/storage/emulated/0/DCIM/Camera";
        //GameObject obj = GameObject.Find("Canvas");
        //picture = obj.GetComponent<CapturePic>().snap;
       // sprite = Sprite.Create(picture, new Rect(0f, 0f, picture.width, picture.height), new Vector2(0.5f, 0.5f), 100.0f);
        //obj.GetComponent<SpriteRen>
    }

    public void SavePhoto()
    {
        File.WriteAllBytes(savePath + System.DateTime.Now.ToString() + ".jpg", picture.EncodeToJPG());
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
