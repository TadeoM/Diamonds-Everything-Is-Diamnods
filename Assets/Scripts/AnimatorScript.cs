using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {
    int framenum = 0;
    SpriteRenderer Rend;
    List<Sprite> Anim = new List<Sprite>();
    float timePassed = 0;
    float timeToPass = .2f;
    // Use this for initialization
    void Start()
    {
        Rend = GetComponent<SpriteRenderer>();
    }
    
	public void Animate(string path, int firstframe, int animlength)
    {
        framenum = 0;
        Anim = new List<Sprite>();
        Sprite[] s = Resources.LoadAll<Sprite>("Sprites/Characters/" + path);
        for (int i = firstframe; i < firstframe+animlength&&i<s.Length; i++)
        {
            Anim.Add(s[i]);
        }
    }
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed >= timeToPass&&Anim.Count>1)
        {
            framenum = framenum % Anim.Count;
            Rend.sprite = Anim[framenum];
            framenum++;
            timePassed = 0;
        }
	}
}
