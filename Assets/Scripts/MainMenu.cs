using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string startLevel;
    public string levelSelect;
    public string credits;

    public int playerLives;

    public int playerHealth;

    public string level1Tag;

    public void NewGame()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("PlayerCurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        PlayerPrefs.SetInt(level1Tag, 1);

        PlayerPrefs.SetInt("PlayerLevelSelect", 0);
        SceneManager.LoadScene(startLevel);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("PlayerCurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        PlayerPrefs.SetInt(level1Tag, 1);

        if(!PlayerPrefs.HasKey("PlayerLevelSelect"))
        {
            PlayerPrefs.SetInt("PlayerLevelSelect", 0);
        }

        SceneManager.LoadScene(levelSelect);
    }

    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
