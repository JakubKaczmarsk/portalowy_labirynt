using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePickup : Pickup
{
    public int freezeTime = 10;
    public override void Picked()
    {
        base.Picked();
        GameManager.instance.FreezeTime(freezeTime);
    }
    private void Update()
    {
        Rotation();
    }

}
