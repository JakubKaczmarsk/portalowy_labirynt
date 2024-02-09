using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCloak : Pickup
{
    public int timeToAdd = 10;

    public override void Picked()
    {
        base.Picked();
        GameManager.instance.AddTime(timeToAdd);
    }

    private void Update()
    {
        Rotation();
    }
}
