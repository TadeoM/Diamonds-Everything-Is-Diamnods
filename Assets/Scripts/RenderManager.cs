using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

    Node[,] nodes;
    Sprite[] spriteSheet;

	// Use this for initialization
	void Start () {

        spriteSheet = Resources.LoadAll<Sprite>("Sprites");

        nodes = new Node[3, 3];

        // loop through the array of nodes and apply the correct texture
        for (int x = 0; x < nodes.GetLength(0); x++)
        {
            Debug.Log(x);
            for (int y = 0; y < nodes.GetLength(1); y++)
            {
                Debug.Log(y);
                Debug.Log(nodes.GetLength(0));
                //nodes[x, y] = nodes[x, y].gameObject.AddComponent("Node");

                // trying to go into the assets folder and find sprites, then into the spritesheet

                nodes[x, y].tileSprite = spriteSheet[2];
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
