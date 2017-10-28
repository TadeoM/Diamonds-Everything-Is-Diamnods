using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    // variables
    public int[] arrayPosition = { 0, 0 };
    public GameObject turnMinion;//if turnminion == this.gameobject it is your turn
    public int health;
    public int movementSpeed;
    private bool prevMove;
    private Vector3 desiredWorldpos;
    public bool Moving { get { return (desiredWorldpos != transform.position); } }
    private int framesTraveled=0;
	// Use this for initialization
	void Start () {
        desiredWorldpos = transform.position;
        prevMove = Moving;
	}
    public void Move(Vector3 finalpos)
    {
        desiredWorldpos = finalpos;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement
       
        Vector3 currentMovement = transform.position - desiredWorldpos;
        currentMovement = currentMovement / (20-framesTraveled);
        transform.position += currentMovement;
        if (prevMove && !Moving)
        {
            movementSpeed--;
        }
        if (Moving)
        {
            framesTraveled++;
        }
        else { framesTraveled = 0; }
        prevMove = Moving;
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
