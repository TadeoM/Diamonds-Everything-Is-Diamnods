using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //References
    public Manager managerRef;
    public int xPositionInArray;
    public int yPositionInArray;
    public Unit unitOccupyingSpace;
    public int movementRequirement;
    public SpriteRenderer spriteRenderer;
	
	void Awake ()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
    {
        spriteRenderer.color =
            new Color(
                spriteRenderer.color.r + 10,
                spriteRenderer.color.g + 10,
                spriteRenderer.color.b + 10);
	}

    public Node Initialize(int x, int y, int matirial, int wall, int unit)
    {
        if (matirial == 9)
        {
            Destroy(this.gameObject);
            return null;
        }

        xPositionInArray = x;
        yPositionInArray = y;
        spriteRenderer.sprite = RenderManager.spriteSheet[matirial + wall];
        if (unit > 0 && unit < 3)
        {
            unitOccupyingSpace = managerRef.Spawn(new int[] { x, y }, unit).GetComponent<Unit>();
        }
        

        return this;
    }

    private void OnMouseDown()
    {
        if (Manager.activeNode != this)
        {
            Debug.Log(xPositionInArray + ", " + yPositionInArray + " selected");
            Manager.activeNode = this;
        }
        else
        {
            Debug.Log(xPositionInArray + ", " + yPositionInArray + " deselected");
            Manager.activeNode = null;
        }
    }

}
