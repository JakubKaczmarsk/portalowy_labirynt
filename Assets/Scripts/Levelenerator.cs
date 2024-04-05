using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefub[] colorMapping;
    public float offset = 5f;

    private void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if(pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefub colorMapping in colorMapping) 
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x * offset,0,z * offset);
                Instantiate(colorMapping.prefab, position, Quaternion.identity);
            }
        }
    }
}
