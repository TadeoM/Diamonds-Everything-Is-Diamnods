using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("main");
    }
}
