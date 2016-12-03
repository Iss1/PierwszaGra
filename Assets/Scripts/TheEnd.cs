using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour {

    public float waitAfterTheEnd;
    public string mainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        waitAfterTheEnd -= Time.deltaTime;
        if (waitAfterTheEnd < 0)
        {
            SceneManager.LoadScene(mainMenu);
        }

    }
}
