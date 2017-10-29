using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    // variables
    public int[] arrayPosition = { 0, 0 };
    public int health;
    private Vector3 movement;
    public int Moving = 0;
    private int framesTraveled=0;
    Queue<Vector3> Movements=new Queue<Vector3>();
    // Use this for initialization
	void Start () {
        movement = new Vector3();
        
	}
    
    
    public Queue<Vector3> Move(List<Node> path)
    {
        Queue<Vector3> output = new Queue<Vector3>();
        foreach (var item in path)
        {
            Vector3 finalLocation = new Vector3(item.xPositionInArray + item.yPositionInArray, (-(item.yPositionInArray / 2f) + item.xPositionInArray / 2f));
            Vector3 currpath = Vector3.MoveTowards(transform.position, finalLocation, (transform.position - finalLocation).magnitude / 20);
            for (int i = 0; i < 20; i++)
            {
                output.Enqueue(currpath);
            }
        }
        return output;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement


        if (Movements.Count>0)
        {
            transform.position += Movements.Dequeue();
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
