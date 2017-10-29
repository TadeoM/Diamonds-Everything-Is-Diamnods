using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMinion : Unit {

	// Use this for initialization
	void Start () {
        movementSpeed = 2;
        health = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector2 Move(Vector2 targetLocation)
    {

        return new Vector2(0,0);
    }
}
