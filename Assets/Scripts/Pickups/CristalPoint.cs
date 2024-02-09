using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalPoint : Pickup
{
    public int points = 5;

    public override void Picked()
    {
        base.Picked();
        GameManager.instance.AddPoints(points);
    }

    private void Update()
    {
        Rotation();
    }
}
