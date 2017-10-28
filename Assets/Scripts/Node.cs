using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector2 positionInArray;
    public Vector2 positionInWorld;
    public Unit unitOccupyingSpace;
    public int material;
    public int wall;
    public int movementRequirement;     //If -1, tile is impassible
    public SpriteRenderer renderer;
    public Sprite tileSprite;
	
	void Start ()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
    {

	}

    public Node Initialize(int matirial, int wall, int unit)
    {
        return this;
    }

    private void OnMouseEnter()
    {
        
    }


}
