using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectTouch : MonoBehaviour {

    public LevelSelectManager levelSelect;

	// Use this for initialization
	void Start () {
        levelSelect = FindObjectOfType<LevelSelectManager>();

        levelSelect.touchMode = true;
	}

    public void LeftArrow()
    {
        levelSelect.positionSelector -= 1;

        if (levelSelect.positionSelector < 0)
        {
            levelSelect.positionSelector = 0;
        }
    }

    public void RightArrow()
    {
        levelSelect.positionSelector += 1;

        if (levelSelect.positionSelector >= levelSelect.levelTags.Length)
        {
            levelSelect.positionSelector = levelSelect.levelTags.Length - 1;
        }
    }

    public void LoadLevel()
    {
        if (levelSelect.levelUnlocked[levelSelect.positionSelector])
        { 
            PlayerPrefs.SetInt("PlayerLevelSelect", levelSelect.positionSelector);
            SceneManager.LoadScene(levelSelect.levelName[levelSelect.positionSelector]);
        }
    }
}
