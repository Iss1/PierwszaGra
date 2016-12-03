using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

    //public int startingLifes;
    private int lifeCounter;
    private Text theText;
    public GameObject gameOverScreen;
    public PlayerControler player;
    public string mainMenu;
    public float waitAfterDeath;
    

	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();

        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
        player = FindObjectOfType<PlayerControler>();
	}
	
	// Update is called once per frame
	void Update () {

        if(lifeCounter<0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }

        theText.text = "x " + lifeCounter;

        if(gameOverScreen.activeSelf)
        {
            waitAfterDeath -= Time.deltaTime;
        }

        if(waitAfterDeath <0)
        {
            SceneManager.LoadScene(mainMenu);
        }
	}

    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }
}
