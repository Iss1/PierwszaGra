using UnityEngine;
using System.Collections;

public class FlyEnemyMove : MonoBehaviour {

    private PlayerControler player;
    public float MoveSpeed;
    public float playerRange;

    public LayerMask playerLayer;
    public bool playerInRange;
    public bool facingAway;
    public bool followOnLookAway;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControler>();
	}

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        if (!followOnLookAway)
        {
            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
                return;
            }
        }
        if((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) || (player.transform.position.x > transform.position.x && player.transform.localScale.x > 0))
        {
            facingAway = true;
        } else {
            facingAway = false;
        }

        if (playerInRange && facingAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
