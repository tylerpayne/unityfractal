using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceDrawer : MonoBehaviour
{

    public Fractal fractal;
    public Tracer[] tracers;

    public int instancesPerTracer = 1;
    public bool randomize = false;

    private bool ready = false;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < tracers.Length; i++)
        {
            tracers[i].gameObject.SetActive(false);
        }
    }

    void Trace()
    {
        for (int i = 0; i < tracers.Length; i++)
        {
            Tracer t = tracers[i];
            for (int j = 0; j < instancesPerTracer; j++)
            {
                t = Instantiate(t,transform);
                t.gameObject.name = "Tracer";
                if (randomize)
                {
                    t.pathstep = (int)Random.Range(0, fractal.path.Length);
                    t.transform.position = fractal.path[t.pathstep];
                }
                t.gameObject.SetActive(true);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!ready)
        {
            if (fractal.path.Length > 0)
            {
                ready = true;
                Trace();
            }
        }
    }
}
