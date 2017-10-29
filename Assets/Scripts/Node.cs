using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //References
    public Manager managerRef;
    public bool selected = false;
    bool m_down=false;
    bool m_hover=false;
    public int xPositionInArray;
    public int yPositionInArray;
    public Unit unitOccupyingSpace;
    public int material;
    public int wall;
    public int movementRequirement;
    public SpriteRenderer spriteRenderer;
	
	void Awake ()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
    {

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
    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            selected = true;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log(xPositionInArray + ", " + yPositionInArray);
    }

}
