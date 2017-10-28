using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{

    public static Node[,] nodes;

	void Start ()
    {
        Stream inStream = new FileStream(Application.dataPath + "/Maps/map01.txt", FileMode.Open);
        StreamReader reader = new StreamReader(inStream);

        Debug.Log(reader.ReadLine());
        Debug.Log(reader.ReadLine());

        string line;
        string[] splitLine;

        while (true)
        {
            line = reader.ReadLine();

            if (line == null) { break; }

            splitLine = line.Split(' ');

            foreach(string cell in splitLine)
            {
                
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