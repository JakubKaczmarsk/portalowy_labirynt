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
    public override void Picked()
    {
        base.Picked();
        GameManager.instance.AddKey(keyColor);
    }
    private void Update()
    {
        Rotation();
    }
}
