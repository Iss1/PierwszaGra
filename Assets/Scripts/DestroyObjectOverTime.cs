using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    public float liveTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        liveTime -= Time.deltaTime;

        if(liveTime<0)
        {
            Destroy(gameObject);
        }
	}
}
