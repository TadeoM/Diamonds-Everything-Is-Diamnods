using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    // variables
    public int[] arrayPosition = { 0, 0 };
    public int health;
    public int movementSpeed;
    private bool prevMove;
    private Vector3 movement;
    public int Moving = 0;
    private int framesTraveled=0;
	// Use this for initialization
	void Start () {
        movement = new Vector3();
        
	}
    public void Move(Vector3 finalpos)
    {
        Moving = 20;
        movement = (finalpos - transform.position-new Vector3(0,0,2f))/20;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement


        if (Moving > 0)
        {
            transform.position += movement;
            Moving--;
        }
      
       
        
        #endregion

    }

    public void CheckDead()
    {
        if (health <= 0)
        {
            // die
        }
    }
}
