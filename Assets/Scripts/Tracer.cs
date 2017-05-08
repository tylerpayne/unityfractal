using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour {
    public Fractal fractal;
    public int incr = 1, pathstep=0;
    public float speed;
    private float accum;
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, fractal.path[pathstep], Time.deltaTime * speed);
        if (Vector3.Magnitude(transform.position-fractal.path[pathstep]) < 0.1)
        {
            pathstep+=incr;
            if (pathstep >= fractal.path.Length) 
                pathstep = 0;
        }

	}
}
