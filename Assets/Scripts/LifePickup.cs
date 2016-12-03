using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {

    private LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
        lifeSystem =  FindObjectOfType<LifeManager>();
	}
	
	// Update is called once per frame
	void Update () {

   
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="player")
        {
            lifeSystem.GiveLife();
            Destroy(gameObject);
        }
    }
}
