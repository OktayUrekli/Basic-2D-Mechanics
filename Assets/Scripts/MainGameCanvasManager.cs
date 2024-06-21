using UnityEngine;
using UnityEngine.SceneManagement;


public class MainGameCanvasManager : MonoBehaviour
{

    [SerializeField] GameObject pausePanel, gamePausedText;

    

    void Start()
    {
        pausePanel.SetActive(false);
        gamePausedText.SetActive(false);
        Cursor.visible = false;
        
    }


    void Update()
    {
        Inputs();
    }

    

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        Cursor.visible = false;
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}