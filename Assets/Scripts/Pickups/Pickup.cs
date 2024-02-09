using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    protected Vector3 rotationSpeed;

        public virtual void Picked()
        {
            Debug.Log("Picked up!");
            Destroy(gameObject);
        }
    public void Rotation()
    {
        transform.Rotate(rotationSpeed);
    }
}
