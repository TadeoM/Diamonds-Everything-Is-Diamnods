using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMinion : Unit
{
    void Awake()
    {
        gameObject.GetComponent<AnimatorScript>().Animate("enemy-spritesheet", 0, 5);
    }

    void Update()
    {
        
    }
}
