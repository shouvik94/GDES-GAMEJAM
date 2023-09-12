using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRotate : MonoBehaviour
{
    public Transform sprite;
    public float rotateSpeed=0.5f;

    public Canvas onlyfansCanvas;

    void Start()
    {
        onlyfansCanvas.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        sprite.Rotate(new Vector3(0f,0f,rotateSpeed)*Time.deltaTime, Space.Self);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void OnlyFans(){
        onlyfansCanvas.enabled=true;
    }

    public void close(){
        onlyfansCanvas.enabled=false;
    }
}
