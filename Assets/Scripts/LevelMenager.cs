using UnityEngine;
using System.Collections;

public class LevelMenager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerControler player;

    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    private float gravitiStore;

    private CameraControl Camera;

    public HealthManager healthManager;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerControler>();
        Camera = FindObjectOfType<CameraControl>();
        healthManager = FindObjectOfType<HealthManager>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo ()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        Camera.isFollowing = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //gravitiStore = player.GetComponent<Rigidbody2D>().gravityScale;
        ScoreManager.score = 0;
        //player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.transform.position = currentCheckpoint.transform.position;
        player.knockbackCount = 0;

        yield return new WaitForSeconds(respawnDelay);
        Debug.Log("Pleyer Respawn here");
        //player.GetComponent<Rigidbody2D>().gravityScale = gravitiStore;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        Camera.isFollowing = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
