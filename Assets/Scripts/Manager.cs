using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameObject turnUnit;
    public GameObject[] Prefabs;
    public static List<GameObject> allUnits = new List<GameObject>();

    public static Node activeNode;
    public static Node mouseoverNode;
    public static List<Node> highlightedNodes;

    public enum NodeType { empty, fireFighter, fire }
    public NodeType activeNodeType;
    

    void Awake()
    {
        highlightedNodes = new List<Node>();
        activeNodeType = NodeType.empty;
    }

    void Update()
    {
        if (activeNode != null)
        {
            if (activeNode.unitOccupyingSpace == null)
            {
                activeNodeType = NodeType.empty;
            }
            else
            {
                if (activeNode.unitOccupyingSpace.type == Unit.Type.fireFighter)
                {
                    activeNodeType = NodeType.fireFighter;
                }
                else
                {
                    activeNodeType = NodeType.fire;
                }
            }
        }
        else
        {
            activeNodeType = NodeType.empty;
        }

        switch (activeNodeType)
        {
            case NodeType.empty:

                break;

            case NodeType.fireFighter:

                highlightedNodes = activeNode.GetPath()
                activeNode.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

                break;

            case NodeType.fire:

                activeNode.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                break;
        }



        foreach (Node n in highlightedNodes)
        {
            n.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
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
