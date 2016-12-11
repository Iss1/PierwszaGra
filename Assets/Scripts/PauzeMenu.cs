using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauzeMenu : MonoBehaviour {

    public string mainMenu;
    public string levelSelect;
    public bool isPauzed;
    public GameObject pauseMenuCanvas;

    void Update()
    {
        if(isPauzed)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauzeOnPauze();
        }
    }

    public void PauzeOnPauze()
    {
        isPauzed = !isPauzed;
    }

    public void Resume()
    {
        isPauzed = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }

}
