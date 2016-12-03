using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsControl : MonoBehaviour {

    public string menu;

	public void BackToMenu()
    {
        SceneManager.LoadScene(menu);
    }
}
