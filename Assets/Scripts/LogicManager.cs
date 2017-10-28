using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    //References
    //public Node[,] nodes;
    


	void Start ()
    {
        nodes = new Node[2, 2];
	}
	
	
	void Update ()
    {
        // loop through the array of nodes and apply the correct texture
        for (int x = 0; x < nodes.GetLength(0); x++)
        {
            for (int y = 0; y < nodes.GetLength(1); y++)
            {
                // trying to go into the assets folder and find sprites, then into the spritesheet
                //nodes[x, y] = Resources.Load("Sprites");
            }
        }
	}
}
