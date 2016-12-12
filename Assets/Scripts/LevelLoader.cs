using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public bool playerInZone;

    public string levelToLoad;

    public string levelTag;

	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Submit") && playerInZone)
        {
            PlayerPrefs.SetInt(levelTag, 1);
            SceneManager.LoadScene(levelToLoad);
        }
	}

    public void LoadScene()
    {
        PlayerPrefs.SetInt(levelTag, 1);
        SceneManager.LoadScene(levelToLoad);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "player")
        {
            playerInZone = false;
        }
    }
}
