using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public LevelMenager levelMenager;

    // Use this for initialization
    void Start()
    {
        levelMenager = FindObjectOfType<LevelMenager>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            levelMenager.currentCheckpoint = gameObject;
            Debug.Log("Activated Checkpoint" + transform.position);
        }
    }
}
