using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

    Sprite[] spriteSheet;
    Sprite tileSprite;

	// Use this for initialization
	void Start () {

        PositionNodes();
        
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
                Data.nodes[x, y].positionInWorld.x = x*1f;
                Data.nodes[x, y].positionInWorld.y = y*-0.5f;
            }
        }
    }
}
