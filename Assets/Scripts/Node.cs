using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int xPositionInArray;
    public int yPositionInArray;
    public Unit unitOccupyingSpace;
    public int material;
    public int wall;
    public int movementRequirement;
    public SpriteRenderer spriteRenderer;
	
	void Start ()
    {

         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
    {

	}

    public Node Initialize(int x, int y, int matirial, int wall, int unit)
    {
        xPositionInArray = x;
        yPositionInArray = y;
        spriteRenderer.sprite = RenderManager.spriteSheet[matirial + wall];
        return this;
    }


}
