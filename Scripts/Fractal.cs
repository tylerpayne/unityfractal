using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{

    public bool renderPath;
    public float length;
    public Generator generator;
      
    public int iteration = 0;

    public Vector3[] path;
    
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.useWorldSpace = true; 
        }
        if (!renderPath)
        {
            lineRenderer.enabled = false;
        }
        if (iteration == 0)
        {  
            iteration++;
            GameObject go = new GameObject("Root");
            go.SetActive(false);
            Node root = go.AddComponent<Node>();

            root.length = length;
            root.adjacent = new Node[generator.generators.Length + 2];
            root.iteration = 0;
            Generate(root);
            List<Vector3> positions = new List<Vector3>();
            Graph.InOrder(root, positions);
            Debug.Log("Vertex count: " + positions.Count);
            lineRenderer.positionCount = positions.Count;
            path = positions.ToArray();
            lineRenderer.SetPositions(path);
            root.DestroyAll();
        }
    }

    public void Generate(Node n)
    {
        if (n.iteration < generator.maxIteration)
        {
            int count = n.adjacent.Length;

            Node lastchild = Node.MakeChild(n);
            lastchild.iteration++;
            lastchild.transform.position = n.transform.position;
            lastchild.transform.position += n.transform.forward * n.length;
            n.adjacent[count - 1] = lastchild;

            for (int i = count - 2; i > 0; i--)
            {
                Vector3 gen = generator.generators[i-1];

                Node child = Node.MakeChild(n);
                child.iteration++;
                child.transform.position = n.transform.position;
                child.transform.position += n.transform.forward * (n.length * gen.x);
                child.transform.position += n.transform.up * (gen.y * n.length);
                child.transform.position += n.transform.right * (gen.z * n.length);

                Vector3 term = n.adjacent[i + 1].transform.position;
                child.length = (term - child.transform.position).magnitude;
                child.transform.LookAt(term);
                
                n.adjacent[i] = child;
                child.gameObject.SetActive(false);
            }

            Node n1 = Node.MakeChild(n);
            n1.iteration++;
            n1.length = (n.adjacent[1].transform.position - n1.transform.position).magnitude;
            n1.transform.LookAt(n.adjacent[1].transform.position);
            n1.gameObject.SetActive(false);
            n.adjacent[0] = n1;

            if (n.iteration == 0)
            {
                float N = count - 1;
                float e = 0f;
                for (int i = 0; i < count - 1; i++)
                {
                    e += n.adjacent[i].length;
                }
                e /= (float)(count - 1);
                e /= length;
                float D = Mathf.Log(N) / Mathf.Log(e);
                Debug.Log("Fractal Dimension ~= " + -D);
            }

            for (int i = 0; i < count-1; i++)
            {
                Generate(n.adjacent[i]);
            }
        }
    }

    void Update()
    {
        lineRenderer.material = generator.material;
        lineRenderer.startWidth = generator.width;
        lineRenderer.endWidth = generator.width;
    }
}
