using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{
    //References
    public GameObject nodePrefabRef;

    //Variables
    public static Node[,] nodes;
    public Node highlightedNode;

    void Awake()
    {
        Stream inStream = new FileStream(Application.dataPath + "/Maps/map01.txt", FileMode.Open);
        StreamReader reader = new StreamReader(inStream);

        // reads first two lines and initializes array based on the two numbers
        nodes = new Node[int.Parse(reader.ReadLine()), int.Parse(reader.ReadLine())];

        string line;
        string[] splitLine;

        // go through y index
        for (int y = 0; y < nodes.GetLength(1); y++)
        {
            // reads a line
            line = reader.ReadLine();

            if (line == null) { break; }

            splitLine = line.Split(' ');

            // go through x index
            for(int x = 0; x < nodes.GetLength(0); x++)
            {
                Debug.Log("X lengths: " + nodes.GetLength(0));
                Debug.Log("Y lengths: " + nodes.GetLength(1));
                Debug.Log("x: " + x + " y: " + y);
                // for the first one (0,) spawn a node
                nodes[x, y] = Instantiate(nodePrefabRef).GetComponent<Node>();
                // initialize it, and give the data of the 3 numbers
                nodes[x, y].Initialize(
                    x,
                    y,
                    int.Parse(splitLine[x][0].ToString()),
                    int.Parse(splitLine[x][1].ToString()),
                    int.Parse(splitLine[x][2].ToString()));
            }

            Camera.main.orthographicSize = nodes.GetLength(0) * .75f;
            Camera.main.transform.position = new Vector3 (nodes.GetLength(0) - 1, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
	}
	
	void Update ()
    {

	}

    
}



/*FORMAT
abc
a : Matirial Type (wood, tile, carpet, etc)
b : Wall Type (none, left, right, both)
c : Initial Units (none, 
*/