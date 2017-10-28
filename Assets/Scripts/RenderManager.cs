using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

    Sprite[] spriteSheet;

	// Use this for initialization
	void Start () {

        spriteSheet = Resources.LoadAll<Sprite>("Sprites");

        // loop through the array of nodes and apply the correct texture
        for (int x = 0; x < Data.nodes.GetLength(0); x++)
        {
            Debug.Log(x);
            for (int y = 0; y < Data.nodes.GetLength(1); y++)
            {
                Data.nodes[x,y].tileSprite = spriteSheet[]
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
