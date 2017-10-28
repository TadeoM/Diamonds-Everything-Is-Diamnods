using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

    Sprite[] spriteSheet;
    Sprite tileSprite;

	// Use this for initialization
	void Start () {

        spriteSheet = Resources.LoadAll<Sprite>("Sprites/Tiles");
        //Debug.Log(spriteSheet.Length);

        // loop through the array of nodes and apply the correct texture
        for (int x = 0; x < Data.nodes.GetLength(0); x++)
        {
            for (int y = 0; y < Data.nodes.GetLength(1); y++)
            {
                
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
