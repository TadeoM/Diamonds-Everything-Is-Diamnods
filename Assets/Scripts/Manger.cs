using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manger : MonoBehaviour
{
    public static GameObject turnUnit;
    public static GameObject[] prefabs;
    public static List<GameObject> allUnits = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }
    public static GameObject Spawn(int[] arrayposition,int identifier)
    {
        GameObject current = null;
        if (identifier > 0 && identifier <= 2)
        {
            current = Instantiate(prefabs[identifier - 1], new Vector3(arrayposition[0]+arrayposition[1],-(arrayposition[1]/2)+arrayposition[0]/2-.5f), Quaternion.identity);
            current.GetComponent<Unit>().arrayPosition = arrayposition;
            allUnits.Add(current);
        }
        return current;
    }
    // Update is called once per frame
    void Update()
    {

    }


}
