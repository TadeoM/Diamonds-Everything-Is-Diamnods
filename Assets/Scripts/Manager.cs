using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameObject turnUnit;
    public GameObject[] Prefabs;
    public static List<GameObject> allUnits = new List<GameObject>();

    public static Node activeNode;
    public static List<Node> highlightedNodes;
    

    void Awake()
    {
        highlightedNodes = new List<Node>();
    }

    void Update()
    {
        if (activeNode != null)
        {
            activeNode.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        foreach (Node n in highlightedNodes)
        {
            n.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
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
}
