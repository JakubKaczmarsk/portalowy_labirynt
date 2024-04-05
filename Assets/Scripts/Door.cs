using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform closePosition;
    public Transform openPosition;
    public Transform door;

    public float speed = 5f;

    public bool open = false;

    private void Start()
    {
        if (open)
        {
            door.position = openPosition.position;
        }
        else
        {
            door.position = closePosition.position;
        }



    }

    public void Open()
    {
        open = true;
    }

    private void Update()
    {
        if (open && Vector3.Distance(door.position, openPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, speed * Time.deltaTime);
        }
    }






}