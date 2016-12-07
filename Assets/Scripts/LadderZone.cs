using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private PlayerControler thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerControler>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            thePlayer.onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "player")
        {
            thePlayer.onLadder = false;
        }
    }
}
