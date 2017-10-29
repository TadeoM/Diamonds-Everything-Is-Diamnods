using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFighters : Unit
{
    public GameObject hadokenRef;
    public bool fired = false;
    private Vector3 previousPosition;
    private AnimatorScript animatorScript;
    private bool inAnimation;


    public void Fire(Vector3 target)
    {
        Vector3 direction = target - transform.position;

        HadokenMove temp = Instantiate(
            hadokenRef,
            transform.position,
            Quaternion.Euler(
                0,
                0,
                Mathf.Atan(direction.y / direction.x) / Mathf.PI * 180 + ((direction.x < 0) ? 180 : 0))
                ).GetComponent<HadokenMove>();

        temp.target = target;
    }

    private void Awake()
    {
        animatorScript = gameObject.GetComponent<AnimatorScript>();
    }


    private void FixedUpdate()
    {
        if (Movements.Count > 0)
        {
            transform.position += Movements.Dequeue();
        }

        if (previousPosition == transform.position)
        {
            animatorScript.Animate("fireman-sprite", 1, 1);
            inAnimation = false;
        }
        else if (!inAnimation)
        {
            animatorScript.Animate("fireman-sprite", 1, 5);
            inAnimation = true;
        }

        previousPosition = transform.position;
    }
}
