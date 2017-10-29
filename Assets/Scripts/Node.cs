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
                spriteRenderer.color.r + 1,
                spriteRenderer.color.g + 1,
                spriteRenderer.color.b + 1);
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

            switch (unit)
            {
                case 1:
                    unitOccupyingSpace.type = Unit.Type.fireFighter;
                    break;
                case 2:
                    unitOccupyingSpace.type = Unit.Type.fire;
                    break;
            }

           
        }
        

        return this;
    }

    private void OnMouseDown()
    {
        if (Manager.setActiveNode != this)
        {
            Debug.Log(xPositionInArray + ", " + yPositionInArray + " selected");
            Manager.setActiveNode = this;
        }
        else
        {
            Debug.Log(xPositionInArray + ", " + yPositionInArray + " deselected");
            Manager.setActiveNode = null;
        }
    }

    private void OnMouseEnter()
    {
        Manager.mouseoverNode = this;
        Debug.Log(xPositionInArray + ", " + yPositionInArray);
    }
}
