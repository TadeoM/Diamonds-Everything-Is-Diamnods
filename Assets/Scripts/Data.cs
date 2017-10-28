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

	void Start ()
    {
        Stream inStream = new FileStream(Application.dataPath + "/Maps/map01.txt", FileMode.Open);
        StreamReader reader = new StreamReader(inStream);

        nodes = new Node[int.Parse(reader.ReadLine()), int.Parse(reader.ReadLine())];

        string line;
        string[] splitLine;

        for (int y = 0; y < nodes.GetLength(1); y++)
        {
            line = reader.ReadLine();

            if (line == null) { break; }

            splitLine = line.Split(' ');

            for(int x = 0; x < nodes.GetLength(0); x++)
            {
                nodes[x, y] = Instantiate<GameObject>(nodePrefabRef).GetComponent<Node>();
                nodes[x, y].Initialize(
                    int.Parse(splitLine[x][0].ToString()),
                    int.Parse(splitLine[x][1].ToString()),
                    int.Parse(splitLine[x][2].ToString()));
            }
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
c : Initial Units
*/