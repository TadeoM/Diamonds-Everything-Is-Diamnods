using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFighters : Unit {
    bool hovering=false;
    public GameObject gun;
    public bool selected = false;
	// Use this for initialization
	void Start () {
        movementSpeed = 3;
        health = 3;
	}

    // Update is called once per frame
    void Update()
    {
        CheckDead();
        CheckInputs();
    }
    
    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            print("did it");
            selected = true;
        }
        
    }
    /// <summary>
    /// check for inputs
    /// </summary>
    void CheckInputs()
    {
        // player presses S
        if (Input.GetKeyDown(KeyCode.S))
        {
            ShowRange();
        }
    }

    void ShowRange()
    {
        // tint the area that is valid to shoot

        // player chooses a place to shoot and presses left mouse button
        if (Input.GetButtonDown("fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // shoot at target location
    }
}
