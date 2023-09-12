using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMainMenu : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas levelsCanvas;


    void Start()
    {
        mainCanvas.enabled=true;
        levelsCanvas.enabled=false;
    }

    public void StartGame(){
        Time.timeScale=1;
        SceneManager.LoadScene(1);
    }

    public void LevelSelect(){
        mainCanvas.enabled=false;
        levelsCanvas.enabled=true;
    }

    public void back(){
        levelsCanvas.enabled=false;
        mainCanvas.enabled=true;
    }

    public void ExitGame(){
        Debug.Log("game quit");
        Application.Quit();
    }

    public void LoadLevel(int index){
        Time.timeScale=1;
        SceneManager.LoadScene(index);
    }

    public void credits(){
        SceneManager.LoadScene(8);
    }
}
