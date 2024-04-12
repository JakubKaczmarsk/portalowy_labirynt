using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Texture2D map;
    public ColorToPrefub[] colorMapping;
    public float offset = 5f;

    private void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefub colorMapping in colorMapping)
        {
            if (/*colorMapping.color.Equals(pixelColor*/ pixelColor.r - 0.004 <= colorMapping.color.r && pixelColor.r + 0.004 >= colorMapping.color.r
                && pixelColor.g - 0.004 <= colorMapping.color.g && pixelColor.g + 0.004 >= colorMapping.color.g
                && pixelColor.b - 0.004 <= colorMapping.color.b && pixelColor.b + 0.004 >= colorMapping.color.b)
            {
                Vector3 position = new Vector3(x * offset, 0, z * offset);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }

        }
    }
    public void GenerateLabirynth()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
        ColorTheChildren();

    }
    public void ColorTheChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "wall")
            {
                foreach (Transform subChild in child)
                {
                    if (Random.Range(1, 100) % 3 == 0)
                    {
                        subChild.gameObject.GetComponent<Renderer>().material = material1;
                    }
                    else
                    {
                        subChild.gameObject.GetComponent<Renderer>().material = material2;
                    }
                }
            }
        }
    }
}