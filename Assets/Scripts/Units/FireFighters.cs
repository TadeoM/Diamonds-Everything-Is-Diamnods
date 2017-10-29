using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFighters : Unit
{
    public GameObject hadokenRef;

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
}
