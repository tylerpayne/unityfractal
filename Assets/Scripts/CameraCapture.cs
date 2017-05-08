using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCapture : MonoBehaviour {
    public KeyCode shutter = KeyCode.K;
    public int width,height,burstCount = 1;
    public float burstInterval = 0f;
    public string filepath = "image.png";
    
    private Camera cam;
    private int iter, burstProgress = 0;

	void Start () {
        cam = GetComponent<Camera>();
	}

    Texture2D CaptureFrame()
    {
        RenderTexture old = RenderTexture.active;
        RenderTexture image = new RenderTexture(width, height, 24);
        RenderTexture.active = image;
        cam.targetTexture = image;
        cam.Render();
        Texture2D save = new Texture2D(width, height, TextureFormat.RGB24, false);
        save.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        save.Apply();
        cam.targetTexture = old;
        RenderTexture.active = old;
        cam.Render();
        return save;
    }

    void SaveFile(byte[] bytes, string path)
    {
        File.WriteAllBytes(path, bytes);
        Debug.Log("Saved " + path);
    }

    IEnumerator Save()
    {
        yield return new WaitForEndOfFrame();
        for (;burstProgress < burstCount; burstProgress++)
        {
            SaveFile(CaptureFrame().EncodeToPNG(), filepath + iter++ + ".png");
            yield return new WaitForSeconds(burstInterval);
        }
        burstProgress = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(shutter)) 
            StartCoroutine(Save());
	}
}
