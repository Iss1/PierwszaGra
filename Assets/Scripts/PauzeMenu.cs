using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauzeMenu : MonoBehaviour {

    public string mainMenu;
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
            isPauzed = !isPauzed;
        }
    }

    public void Resume()
    {
        isPauzed = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
