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
	}
	
	void Update ()
    {
		
	}
}
