/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public float terminator, speed;
    public Generator generators;

    public int iteration = 0;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
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
                child.transform.position += transform.forward * (terminator * generator.x);
                child.transform.position += transform.up * (generator.y * terminator);
                child.transform.position += transform.right * (generator.z * terminator);

                Vector3 term;
                if (i == count - 1)
                {
                    term = transform.position + transform.forward.normalized * terminator;
                }
                else
                {
                    term = children[i + 1];
                }
                child.terminator = (term - child.transform.position).magnitude;
                child.transform.LookAt(term);
                children[i] = child.transform.position;
                child.gameObject.SetActive(true);
                child.Generate();
            }

            iteration++;
            Vector3 fvec = children[0] - transform.position;
            transform.LookAt(children[0]);
            terminator = fvec.magnitude;

        }
    }

    void Update()
    {
        Vector3 end = new Vector3(0, 0, terminator);
        lineRenderer.SetPosition(1, end);
        lineRenderer.material = generators.material;
        lineRenderer.startWidth = generators.width;
        lineRenderer.endWidth = generators.width;
        Generate();
    }
}
*/