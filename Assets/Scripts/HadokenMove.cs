using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadokenMove : MonoBehaviour {
    public Vector3 target;
    bool exploded = false;
    int explosiontimer = -5;
	// Use this for initialization
	void Start () {
        GetComponent<AnimatorScript>().Animate("water-spritesheet", 0, 1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards(transform.position, target, .5f);
        if ((transform.position - target).magnitude < .01f&&!exploded)
        {
            GetComponent<AnimatorScript>().Animate("water-spritesheet", 1, 4);
            exploded = true;
            explosiontimer = 30;
        }
        if (explosiontimer > 0)
        {
            explosiontimer--;
        }
        if (explosiontimer == 0)
        {
            Destroy(gameObject);
        }
	}
}
