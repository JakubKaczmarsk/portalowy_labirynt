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
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x * offset, 0, z * offset);
                Instantiate(colorMapping.prefab, position, Quaternion.identity);
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


    }
  /*  public void ColorTheChildern()
    {
        foreach(Transform child in transform)
        {
            if(child.tag == "Wall")
            {
                if (Random(1, 100) % 3 == 0)
                {
                    child.gameObject.GetComponent<Renderer>().material = material1;
                }
                else
                {
                    child.gameObject.GetComponent<Renderer>().material = material2;
                }
            }
            if(child.childCount > 0)
            {

            }
        }
    }*/
}