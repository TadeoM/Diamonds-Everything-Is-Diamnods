using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMinion : Unit {

	// Use this for initialization
	void Start () {
        movementSpeed = 2;
        health = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector2 Move(Vector2 targetLocation)
    {

        return new Vector2(0,0);
    }

    public List<Node> GetPath(Vector2 currentPos, Vector2 desiredPos)
    {
        List<Node> path = new List<Node>();
        //Data.nodes[(int)currentPos.x, (int)currentPos.y];

        Vector2 distance = desiredPos - currentPos;
        //Data.nodes[(int)currentPos.x+1, (int)currentPos.y].unitOccupyingSpace = Data.nodes[(int)currentPos.x, (int)currentPos.y].unitOccupyingSpace;
        //Debug.Log(distance.x + " " + distance.y);
        if (distance.x > 0)
        {
            for (int x = 0; x < distance.x; x++)
            {
                path.Add(Data.nodes[(int)currentPos.x + x, (int)currentPos.y]);
            }
        }
        else
        {
            for (int x = 0; x > distance.x; x--)
            {
                path.Add(Data.nodes[(int)currentPos.x + x, (int)currentPos.y]);
            }
        }

        if (distance.y > 0)
        {
            for (int y = 0; y <= distance.y; y++)
            {
                path.Add(Data.nodes[(int)distance.x, (int)currentPos.y + y]);
            }
        }
        else
        {
            for (int y = 0; y >= distance.y; y--)
            {
                path.Add(Data.nodes[(int)distance.x, (int)currentPos.y + y]);
            }
        }


        while (path.Count > movementSpeed+1)
        {
            path.RemoveAt(path.Count-1);
        }

        foreach (Node item in path)
        {
            Debug.Log(item.xPositionInArray + ", " + item.yPositionInArray);
        }
        

        return null;
    }
}
