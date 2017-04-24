using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform me;
    public bool always;

	// Use this for initialization
	void Start () {
        Look();
	}

    void Look()
    {
        transform.LookAt(me.position);  
    }
	
	// Update is called once per frame
	void Update () {
        if (always)
        {
            Look();
        }
	}
}
