using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum KeyColor
{
    Red,
    Green,
    Blue
}

public class PickupKeys : Pickup
{
    public KeyColor keyColor;

    public Material red;
    public Material green;
    public Material blue;

    public override void Picked()
    {
        base.Picked();
        GameManager.instance.AddKey(keyColor);
    }
    private void Update()
    {
        Rotation();
    }

    private void SetMyColor()
    {
        switch (keyColor)
        {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                break;
            case KeyColor.Blue:
                GetComponent<Renderer>().material= blue;
        }
    }
}
