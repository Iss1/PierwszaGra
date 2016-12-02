using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            HealthManager.HurtPlayer(damageToGive);
            other.GetComponent<AudioSource>().Play();
            var player = other.GetComponent<PlayerControler>();
            player.knockbackCount = player.knockbackLength;

            if (other.transform.position.x < transform.position.x)
                player.knockFromRigth = true;
            else
                player.knockFromRigth = false;
        }
    }
}
