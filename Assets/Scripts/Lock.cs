using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Door[] doors;
    public KeyColor myColor;
    private bool canOpen = false;
    private bool locked = false;
    private Animator key;

    private void Start()
    {
        key = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
            Debug.Log("Can open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            Debug.Log("Can't open");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    public bool CheckTheKey()
    {
        if (GameManager.instance.keys[(int)KeyColor.Red] > 0 && myColor == KeyColor.Red)
        {
            GameManager.instance.keys[(int)KeyColor.Red]--;
            locked = true;
            return true;
        }
        else if (GameManager.instance.keys[(int)KeyColor.Green] > 0 && myColor == KeyColor.Green)
        {
            GameManager.instance.keys[(int)KeyColor.Green]--;
            locked = true;
            return true;
        }
        else if (GameManager.instance.keys[(int)KeyColor.Blue] > 0 && myColor == KeyColor.Blue)
        {
            GameManager.instance.keys[(int)KeyColor.Blue]--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("No key");
            return false;
        }
    }
    public void UseKey()
    {
        foreach (var door in doors)
        {
            door.Open();
        }
    }


}
