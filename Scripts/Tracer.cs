using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour {
    public Fractal fractal;
    public int incr = 1;
    public float speed;
    private float accum;
    public int pathstep = 0;
	// Use this for initialization
	void Start () {
        //transform.position = fractal.path[pathstep];
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, fractal.path[pathstep], Time.deltaTime * speed);
        if (Vector3.Magnitude(transform.position-fractal.path[pathstep]) < 0.1)
        {
            pathstep+=incr;
            if (pathstep >= fractal.path.Length)
            {
                pathstep = 0;
            }
        }

	}
}
