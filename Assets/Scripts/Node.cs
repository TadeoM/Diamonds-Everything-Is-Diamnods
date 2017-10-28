using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Unit unitOccupyingSpace;
    public int material;
    public int wall;
    public int movementRequirement;     //If -1, tile is impassible
    public Sprite tileSprite;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {

	}

    public Node Initialize(int matirial, int wall, int unit)
    {
        return this;
    }
}
