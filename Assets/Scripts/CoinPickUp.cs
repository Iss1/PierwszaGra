using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour {

    public int pointsToAdd;

    public AudioSource collectSound;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<PlayerControler>() == null)
            return;
        ScoreManager.AddPoints(pointsToAdd);

        collectSound.Play();

        Destroy(gameObject);
    }
	
}
