using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadokenMove : MonoBehaviour {
    public Vector3 target;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, .5f);
        if ((transform.position - target).magnitude < .01f)
        {
            //GetComponent<AnimatorScript>().Animate(/*animation*/)
        }
	}
}
