using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    bool friendlyturn = false;
    public static GameObject turnUnit;
    public GameObject[] Prefabs;
    public static List<GameObject> allUnits = new List<GameObject>();
    
    // Use this for initialization
    void Awake()
    {
        
    }
    public GameObject Spawn(int[] arrayposition,int identifier)
    {
        GameObject current = null;
        if (identifier > 0 && identifier <= 2)
        {
            current = Instantiate(Prefabs[identifier - 1], new Vector2(arrayposition[0] + arrayposition[1], (-(arrayposition[1] / 2f) + arrayposition[0] / 2f) - .5f), Quaternion.identity);
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
