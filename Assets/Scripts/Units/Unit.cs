using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public int movementSpeed = 3;
    public int[] arrayPosition = { 0, 0 };
    public int health;

    public enum Type { fireFighter, fire };
    public Type type;

    public Queue<Vector3> Movements = new Queue<Vector3>();

	void Start () {
        
	}
    
    void FixedUpdate()
    {
        if (Movements.Count > 0)
        {
            transform.position += Movements.Dequeue();
        }
    }

    
    public void Move(List<Node> path)
    {
        if (path.Count < 2) { return; }

        Queue<Vector3> output = new Queue<Vector3>();

        for (int i = 1; i < path.Count; i++)
        {
            Vector3 pathStep = 
                path[i].transform.position - 
                path[i - 1].transform.position;

            for (float j = 0; j < 20; j++)
            {
                output.Enqueue(pathStep * .05f);
            }
        }

        Movements = output;
    }

    public void oldMove(List<Node> path)
    {
        Queue<Vector3> output = new Queue<Vector3>();
        foreach (var item in path)
        {
            Vector3 finalLocation = new Vector3(item.xPositionInArray + item.yPositionInArray, (-(item.yPositionInArray / 2f) + item.xPositionInArray / 2f));
            Vector3 currpath = Vector3.MoveTowards(transform.position, finalLocation, (transform.position - finalLocation).magnitude / 20);
            for (int i = 0; i < 20; i++)
            {
                output.Enqueue(currpath);
            }
        }
        Movements = output;
    }

    public List<Node> GetPath(Vector2 currentPos, Vector2 desiredPos)
    {
        List<Node> path = new List<Node>();

        Vector2 distance = desiredPos - currentPos;
        
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
                path.Add(Data.nodes[(int)desiredPos.x, (int)currentPos.y + y]);
            }
        }
        else
        {
            for (int y = 0; y >= distance.y; y--)
            {
                path.Add(Data.nodes[(int)desiredPos.x, (int)currentPos.y + y]);
            }
        }


        while (path.Count > movementSpeed + 1)
        {
            path.RemoveAt(path.Count - 1);
        }

        foreach (Node item in path)
        {
            //Debug.Log(item.xPositionInArray + ", " + item.yPositionInArray);
        }
        
        return path;
    }
}
