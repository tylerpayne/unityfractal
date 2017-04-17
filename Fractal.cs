using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public float length;
    public Generator generators;

    public int iteration = 0;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.useWorldSpace = false; 
        }
        if (iteration == 0)
        {
            Generate();
        }
    }

    public void Generate()
    {
        if (iteration < generators.maxIteration)
        {
            int count = generators.generators.Length;
            Vector3[] children = new Vector3[count];

            for (int i = count - 1; i >= 0; i--)
            {
                Vector3 generator = generators.generators[i];

                Fractal child = Instantiate(this);
                child.iteration++;
                child.transform.position = transform.position;
                child.transform.position += transform.forward * (length * generator.x);
                child.transform.position += transform.up * (generator.y * length);
                child.transform.position += transform.right * (generator.z * length);

                Vector3 term;
                if (i == count - 1)
                {
                    term = transform.position + transform.forward.normalized * length;
                }
                else
                {
                    term = children[i + 1];
                }
                child.length = (term - child.transform.position).magnitude;
                child.transform.LookAt(term);
                children[i] = child.transform.position;
                child.gameObject.SetActive(true);
                child.Generate();
            }

            iteration++;
            Vector3 fvec = children[0] - transform.position;
            transform.LookAt(children[0]);
            length = fvec.magnitude;

        }
    }

    void Update()
    {
        Vector3 end = new Vector3(0, 0, length);
        lineRenderer.SetPosition(1, end);
        lineRenderer.material = generators.material;
        lineRenderer.startWidth = generators.width;
        lineRenderer.endWidth = generators.width;
        Generate();
    }
}
