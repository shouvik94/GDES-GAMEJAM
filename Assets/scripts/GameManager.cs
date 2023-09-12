using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int state;

    [Header("Pausing")]
    public Canvas pauseCanvas;
    private bool paused;

    [Header("lvl complete")]
    public Canvas lvlCompleteCanvas;
    
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        state = 0;
        //pausing stuff:
            paused=false;
            pauseCanvas.enabled=false;
        //lvl complete stuff:
            lvlCompleteCanvas.enabled=false;
        Time.timeScale=1;
    }

    void Update()
    {
        if(state==2){
            LevelComplete();
        }
        playerInput();
    }

    void playerInput(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Pausegame();
        }
    }

    public void IncrementState(){
        state++;
    }

    public void GameOver(){
        //gameovercanvas
        Debug.Log("you lost sucka");
        RestartGame();
    }

    public void Pausegame(){
        if(!paused){
            Time.timeScale=0;
            pauseCanvas.enabled=true;
            Cursor.lockState=CursorLockMode.None;
            Cursor.visible=true;
        }
        else if(paused){
            Time.timeScale=1;
            pauseCanvas.enabled=false;
            Cursor.lockState=CursorLockMode.Locked;
            Cursor.visible=false;
        }
        paused=!paused;
    }

    public void RestartGame(){
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    void LevelComplete(){
        Time.timeScale=0;
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
        lvlCompleteCanvas.enabled=true;
        Debug.Log("You finished ig");
    }

    public void NextScene(){
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
