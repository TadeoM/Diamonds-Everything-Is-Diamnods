using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static GameObject turnUnit;
    public GameObject[] Prefabs;
    public static List<GameObject> allUnits = new List<GameObject>();

    public static Node setActiveNode;
    private Node activeNode;
    public static Node mouseoverNode;
    public static List<Node> highlightedNodes;

    public enum NodeType { empty, fireFighter, fire }
    public NodeType activeNodeType;
    public Text text;

    public static float pulser;
    private float pulserTimer;
    

    void Awake()
    {
        highlightedNodes = new List<Node>();
        activeNodeType = NodeType.empty;
    }

    void Update()
    {
        pulserTimer += .1f;
        pulser = Mathf.Sin(pulserTimer) / 2 + .5f;


        //Determines behavior when another tile is CLICKED and active tile is FireFighter
        if( activeNode != setActiveNode && activeNodeType == NodeType.fireFighter )
        {
            switch (GetNodeType(setActiveNode))
            {
                case NodeType.empty:
                    if(activeNode.unitOccupyingSpace.Movements.Count > 0) { return; }
                    activeNode.unitOccupyingSpace.Move(highlightedNodes);
                    setActiveNode.unitOccupyingSpace = activeNode.unitOccupyingSpace;
                    activeNode.unitOccupyingSpace = null;

                    break;

                case NodeType.fireFighter:
                    break;

                case NodeType.fire:
                    activeNode.unitOccupyingSpace.gameObject.GetComponent<FireFighters>().Fire(setActiveNode.transform.position);
                    break;
            }
        }

        activeNode = setActiveNode;


        activeNodeType = GetNodeType(activeNode);

        //Determines PASSIVE behavior of the active tile
        switch (activeNodeType)
        {
            case NodeType.empty:

                highlightedNodes.Clear();

                break;

            case NodeType.fireFighter:

                switch (GetNodeType(mouseoverNode))
                {
                    case NodeType.empty:
                        highlightedNodes = activeNode.unitOccupyingSpace.GetComponent<FireFighters>().GetPath(
                            new Vector2(
                                activeNode.xPositionInArray,
                                activeNode.yPositionInArray
                                ),
                            new Vector2(
                                mouseoverNode.xPositionInArray,
                                mouseoverNode.yPositionInArray)
                                );

                        break;

                    case NodeType.fireFighter:
                        highlightedNodes.Clear();
                        mouseoverNode.gameObject.GetComponent<SpriteRenderer>().color = new Color(pulser, 1, pulser);

                        //Highlighted Fireman GUI

                        break;

                    case NodeType.fire:
                        highlightedNodes.Clear();
                        mouseoverNode.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, pulser, pulser);

                        //Chance to extinguish GUI

                        break;
                }

                activeNode.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                SetText(null);

                break;

            case NodeType.fire:

                activeNode.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                highlightedNodes.Clear();
                SetText(null);

                break;
        }



        foreach (Node n in highlightedNodes)
        {
            if (n == activeNode) { continue; }
            n.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }


    private void Baseline()
    {
        highlightedNodes.Clear();

    }

    private NodeType GetNodeType(Node node)
    {
        if (node != null)
        {
            if (node.unitOccupyingSpace == null)
            {
                return NodeType.empty;
            }
            else
            {
                if (node.unitOccupyingSpace.type == Unit.Type.fireFighter)
                {
                    return NodeType.fireFighter;
                }
                else
                {
                    return NodeType.fire;
                }
            }
        }
        else
        {
            return NodeType.empty;
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

    void SetText(Sprite spriteHead)
    {
        string health = activeNode.unitOccupyingSpace.health.ToString();
        //int dewIt = activeNode.unitOccupyingSpace.movementSpeed - activeNode.unitOccupyingSpace.moved;
        //string movementLeft = dewIt.ToString();
        //text.text = "Health: " + health + "\nMove Left: " + movementLeft;
    }
}
