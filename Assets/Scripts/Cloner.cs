using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour {

    public enum cloneType
    {
        Translate,
        Rotate,
        Scale
    };

    public GameObject source;
    public cloneType type = cloneType.Translate;
    public int iterations;
    public Vector3 pivot;
    public float step, falloff = 1;

	// Use this for initialization
	void Start () {
        iterations = (int)Mathf.Clamp(iterations, 0, int.MaxValue);
        for (int i = 1; i < iterations+1; i++)
        {
            GameObject clone = Instantiate(source);
            clone.name = source.name + " Clone " + i;
            if (type == cloneType.Translate)
                clone.transform.position += pivot * step * i * falloff;
            else if (type == cloneType.Scale)
                clone.transform.localScale += pivot * step * i;
            else if (type == cloneType.Rotate)
                clone.transform.Rotate(pivot, step * i * falloff);
            clone.SetActive(true);
        }
	}
}
