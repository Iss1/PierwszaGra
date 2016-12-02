using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;

    public GameObject deathEffect;

    public int pointsOnDeath;

    private SpawnControl spawn;

    // Use this for initialization
    void Start () {
        spawn = FindObjectOfType<SpawnControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(enemyHealth<=0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsOnDeath);
            Destroy(gameObject);
            spawn.SpawnEnemy();
        }

	}

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
        GetComponent<AudioSource>().Play();
    }
}
