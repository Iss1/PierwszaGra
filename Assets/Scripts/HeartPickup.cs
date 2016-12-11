using UnityEngine;
using System.Collections;

public class HeartPickup : MonoBehaviour {

    public int healthToGive;

    public AudioSource collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControler>() == null)
            return;
        HealthManager.HurtPlayer(-healthToGive);

        collectSound.Play();

        Destroy(gameObject);
    }
}
