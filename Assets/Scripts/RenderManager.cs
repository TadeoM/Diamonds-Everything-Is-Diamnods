using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

    public static Sprite[] spriteSheet;

	// Use this for initialization
	void Start () {

        PositionNodes();

        spriteSheet = Resources.LoadAll<Sprite>("Sprites/Tiles");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    /// <summary>
    /// move nodes to correct position
    /// </summary>
    void PositionNodes()
    {
        for (int x = 0; x < Data.nodes.GetLength(0); x++)
        {
            for (int y = 0; y < Data.nodes.GetLength(1); y++)
            {
                float xPos = x;
                float yPos = y;

                Data.nodes[x, y].transform.position = new Vector2(xPos + 0.5f,-(yPos/2f));
            }
        }
    }
}
