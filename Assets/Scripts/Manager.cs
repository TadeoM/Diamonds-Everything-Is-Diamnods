using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    bool friendlyturn = false;
    public static GameObject turnUnit;
    public GameObject[] Prefabs;
    public static List<GameObject> allUnits = new List<GameObject>();
    int timesDone = 0;
    
    // Use this for initialization
    void Awake()
    {
        
    }
    public GameObject Spawn(int[] arrayposition,int identifier)
    {
        GameObject current = null;
        if (identifier > 0 && identifier <= 2)
        {
            current = Instantiate(Prefabs[identifier - 1], new Vector2(arrayposition[0] + arrayposition[1], (-(arrayposition[1] / 2f) + arrayposition[0] / 2f)), Quaternion.identity);
            current.GetComponent<Unit>().arrayPosition = arrayposition;
            current.GetComponent<SpriteRenderer>().sortingOrder = arrayposition[1] - arrayposition[0] + 32;
            allUnits.Add(current);
        }
        return current;
    }
    // Update is called once per frame
    void Update()
    {
        timesDone++;
        if (timesDone == 60)
        {
            //Debug.Log(Data.nodes[i, j].unitOccupyingSpace.name);
            Vector2 currentPos = new Vector2(0, 0);
            Vector2 desiredPos = new Vector2(2, 3);
            //Debug.Log(i + " " + j);
            FireMinion script = Data.nodes[1, 4].unitOccupyingSpace.GetComponent<FireMinion>();
            script.GetPath(currentPos, desiredPos);

        }
    }


}
