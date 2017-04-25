using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCapture : MonoBehaviour {
    public int width,height;
    public string filepath = "image.png";
    public bool Snap = false;
    private bool fired = false;
    private Camera cam;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}

    void Save()
    {
        Debug.Log("Taking Photo");
        fired = true;
        RenderTexture image = new RenderTexture(width, height, 24);
        cam.targetTexture = image;
        cam.Render();
        RenderTexture.active = image;
        Texture2D save = new Texture2D(width,height,TextureFormat.RGB24,false);
        save.ReadPixels(new Rect(0,0,width,height),0,0);    
        byte[] bytes = save.EncodeToPNG();
        File.WriteAllBytes(filepath, bytes);
        fired = false;
        Snap = false;
        Debug.Log("Saved " + filepath);
    }
	
	// Update is called once per frame
	void Update () {
        if (Snap && !fired)
        {
            Save();
        }
	}
}
