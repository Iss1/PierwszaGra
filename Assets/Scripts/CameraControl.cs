using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public PlayerControler player;
    public bool isFollowing;
    public float x0Offset;
    public float y0Offset;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerControler>();
        isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFollowing)
            transform.position = new Vector3(player.transform.position.x+ x0Offset, player.transform.position.y + y0Offset, transform.position.z);

	}
}
