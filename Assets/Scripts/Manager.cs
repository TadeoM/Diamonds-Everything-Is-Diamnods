using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    //References
    public GameObject[] Prefabs;
    public static List<GameObject> fireFighterUnits = new List<GameObject>();
    public static List<GameObject> fireUnits = new List<GameObject>();
    public GameObject pannelRef;
    public Canvas canvasRef;

    //Node Storage
    private Node activeNode;
    public static Node setActiveNode;
    public static Node mouseoverNode;
    public static List<Node> highlightedNodes;

    //Enum for labeling a node
    public enum NodeType { empty, fireFighter, fire }
    public NodeType activeNodeType;

    //UI References
    public List<Image> UIPannels = new List<Image>();
    public List<Text> UItexts = new List<Text>();

    //Pulser Variables
    public static float pulser;
    private float pulserTimer;

    //Enemy Turn Variables
    private bool playerTurn;
    private int enemyTimer;


    void Awake()
    {
        highlightedNodes = new List<Node>();
        activeNodeType = NodeType.empty;

        PopulateUI();
    }

    void Update()
    {
        pulserTimer += .1f;
        pulser = Mathf.Sin(pulserTimer) / 2 + .5f;


        ResettleHomelessFires();
        UpdateUI();


        //Determines behavior when another tile is CLICKED and active tile is FireFighter
        if( activeNode != setActiveNode && activeNodeType == NodeType.fireFighter )
        {
            switch (GetNodeType(setActiveNode))
            {
                case NodeType.empty:
                    if (activeNode.unitOccupyingSpace.Movements.Count > 0) { return; }
                    if (activeNode.unitOccupyingSpace.Move(highlightedNodes))
                    {
                        setActiveNode.unitOccupyingSpace = activeNode.unitOccupyingSpace;
                        activeNode.unitOccupyingSpace = null;
                    }

                    break;

                case NodeType.fireFighter:

                    break;

                case NodeType.fire:
                    activeNode.unitOccupyingSpace.gameObject.GetComponent<FireFighters>().Fire(setActiveNode.transform.position);
                    float hitDifficulty = (
                        new Vector2(setActiveNode.xPositionInArray, setActiveNode.yPositionInArray) -
                        new Vector2(activeNode.xPositionInArray, activeNode.yPositionInArray)
                        ).magnitude * 25;

                    Debug.Log(hitDifficulty);

                    if (Random.Range(1, 100) > hitDifficulty)
                    {
                        setActiveNode.unitOccupyingSpace.health--;
                    }
                    break;
            }
        }

        activeNode = setActiveNode;


        activeNodeType = GetNodeType(activeNode);

        //Determines PASSIVE behavior of the active tile
        switch (activeNodeType)
        {
            case NodeType.empty:

                Baseline();//highlightedNodes.Clear();

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
                        Baseline();//highlightedNodes.Clear();
                        mouseoverNode.gameObject.GetComponent<SpriteRenderer>().color = new Color(pulser, 1, pulser);

                        

                        break;

                    case NodeType.fire:
                        Baseline();//highlightedNodes.Clear();
                        mouseoverNode.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, pulser, pulser);

                        //Chance to extinguish GUI

                        break;
                }

                activeNode.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

                break;

            case NodeType.fire:

                activeNode.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Baseline();//highlightedNodes.Clear();

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

    public void EndTurn()
    {
        foreach (GameObject ff in fireFighterUnits)
        {
            ff.GetComponent<Unit>().ResetMovement();
        }
        foreach (GameObject f in fireUnits)
        {
            FireMinion fire = f.GetComponent<FireMinion>();
            Vector3 minMagVector = new Vector3(999, 999);

            foreach (GameObject ff in fireFighterUnits)
            {
                FireFighters fireFighter = ff.GetComponent<FireFighters>();

                Vector3 difference = (
                    new Vector3(
                        fireFighter.arrayPosition[0], 
                        fireFighter.arrayPosition[1]) - 
                    new Vector3(
                        fire.arrayPosition[0],
                        fire.arrayPosition[1])
                        );

                if (minMagVector.sqrMagnitude > difference.sqrMagnitude)
                {
                    minMagVector = difference;
                }
            }

            Vector2 origionalPos = new Vector2(fire.arrayPosition[0], fire.arrayPosition[1]);
            Vector2 desiredPos = new Vector2(origionalPos.x + minMagVector.x, origionalPos.y + minMagVector.y);

            fire.Move(fire.GetPath(origionalPos, desiredPos));

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (fire.arrayPosition[0] + i > Data.nodes.GetLength(0) - 1 || fire.arrayPosition[0] + i < 0 || fire.arrayPosition[1] + j < 0 || fire.arrayPosition[1] + j > Data.nodes.GetLength(1) - 1) { continue; }
                    if (Data.nodes[fire.arrayPosition[0] + i, fire.arrayPosition[1] + j].unitOccupyingSpace != null)
                    {
                        if(Data.nodes[fire.arrayPosition[0] + i, fire.arrayPosition[1] + j].unitOccupyingSpace.type == Unit.Type.fireFighter)
                        {
                            Data.nodes[fire.arrayPosition[0] + i, fire.arrayPosition[1] + j].unitOccupyingSpace.health--;
                            if(i == 0 && j == 0) { Data.nodes[fire.arrayPosition[0] + i, fire.arrayPosition[1] + j].unitOccupyingSpace.health--; }
                        }
                    }
                }
            }

            fire.ResetMovement();
        }

    }

    private void ResettleHomelessFires()
    {
        foreach (GameObject f in fireUnits)
        {
            FireMinion fire = f.GetComponent<FireMinion>();
           
            if (Data.nodes[fire.arrayPosition[0], fire.arrayPosition[1]].unitOccupyingSpace == null)
            {
                Data.nodes[fire.arrayPosition[0], fire.arrayPosition[1]].unitOccupyingSpace = fire;
            }
        }
    }

    private void PopulateUI()
    {
        for (int i = 0; i < fireFighterUnits.Count; i++)
        {
            GameObject temp = Instantiate(pannelRef, canvasRef.transform);

            UIPannels.Add(temp.GetComponent<Image>());
            UItexts.Add(temp.GetComponentInChildren<Text>());

            temp.transform.position -= new Vector3(0, i * 77);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < fireFighterUnits.Count; i++)
        {
            FireFighters fireFighter = fireFighterUnits[i].GetComponent<FireFighters>();

            UItexts[i].text = "Health: " + fireFighter.health + "\n" +
                              "Movement: " + fireFighter.movementRemaining;

            if (activeNode != null)
            {
                if (fireFighter == activeNode.unitOccupyingSpace)
                {
                    UIPannels[i].color = new Color(pulser, 1, pulser);
                }
                else
                {
                    UIPannels[i].color = Color.white;
                }
            }
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
            switch (identifier)
            {
                case 1:
                    fireFighterUnits.Add(current);
                    break;
                case 2:
                    fireUnits.Add(current);
                    break;
            }
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
