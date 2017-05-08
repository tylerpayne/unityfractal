using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int iteration;
    public float length;
    public Node parent;
    public Node[] adjacent;

    public void Connect(Node n, int id)
    {
        adjacent[id] = n;
    }

    public void DestroyAll()
    {
        if (adjacent[0] == null)
        {
            Destroy(gameObject);
            return;
        }
        for (int i = 0; i < adjacent.Length; i++)
        {
            adjacent[i].DestroyAll();
        }
        Destroy(gameObject);
    }

    static public Node MakeChild(Node n)
    {
        Node r = Instantiate(n);
        n.gameObject.name = "Node";
        r.iteration = n.iteration;
        r.length = n.length;
        r.parent = n;
        r.adjacent = new Node[n.adjacent.Length];
        return r;
    }

}

public class Graph {

    static int Size(Node n)
    {
        if (n.adjacent.Length == 0)
            return 1;
        int size = 1;
        for (int i = 0; i < n.adjacent.Length; i++)
        {
            size += Size(n.adjacent[i]);
        }

        return size;
    }

	static public void InOrder(Node root, List<Vector3> positions)
    {
        if (root.adjacent[0] == null)
        {
            positions.Add(root.transform.position);
            return;
        }
        for (int i = 0; i < root.adjacent.Length; i++)
        {
            InOrder(root.adjacent[i], positions);
        }
    }

}
