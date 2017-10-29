using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

    public static Sprite[] spriteSheet;
    Sprite tileSprite;

	// Use this for initialization
	void Awake () {
        //spriteSheet = new Sprite[4];
        spriteSheet = Resources.LoadAll<Sprite>("Sprites/Tiles");
        Invoke("PositionNodes", .01f);
        

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
                if (Data.nodes[x, y] != null)
                {
                    Data.nodes[x, y].transform.position = new Vector2(xPos + yPos, -(yPos / 2f) + xPos / 2f);
                }
            }
        }
    }
}
