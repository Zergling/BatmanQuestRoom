using UnityEngine;
using System.Collections;

public class Noise : MonoBehaviour
{
    [Range(2, 512)]
    public int resolution = 256;

    private Texture2D texture;
    public GameObject light;
    // Use this for initialization
    void Start ()
    {
        if (light != null)
        {
            light.SetActive(true);
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        FillTexture();
    }

    private void Awake()
    {
        texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
        texture.name = "Procedural Texture";
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        GetComponent<MeshRenderer>().material.mainTexture = texture;
        FillTexture();
    }

    private void FillTexture()
    {
        if (texture.width != resolution)
        {
            texture.Resize(resolution, resolution);
        }

        float stepSize = 1f / resolution;

        Vector3 point00 = new Vector3(-0.5f, -0.5f);
        Vector3 point10 = new Vector3(0.5f, -0.5f);
        Vector3 point01 = new Vector3(-0.5f, 0.5f);
        Vector3 point11 = new Vector3(0.5f, 0.5f);

        for (int y = 0; y < resolution; y++)
        {
            Vector3 point0 = Vector3.Lerp(point00, point01, (y + 0.5f) * stepSize);
            Vector3 point1 = Vector3.Lerp(point10, point11, (y + 0.5f) * stepSize);
            for (int x = 0; x < resolution; x++)
            {
                Vector3 point = Vector3.Lerp(point0, point1, (x + 0.5f) * stepSize);
                texture.SetPixel(x, y, Color.white * Random.value);
            }
        }
        texture.Apply();
    }
}
