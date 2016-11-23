using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelMenager levelMenager;

	// Use this for initialization
	void Start () {
        levelMenager = FindObjectOfType<LevelMenager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            levelMenager.RespawnPlayer();
        }
    }
}
