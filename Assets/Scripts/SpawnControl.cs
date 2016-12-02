using UnityEngine;
using System.Collections;

public class SpawnControl : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
