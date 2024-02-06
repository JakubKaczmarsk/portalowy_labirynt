using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;
    private CharacterController controller;
    public Transform groundCheck;
    public LayerMask GroundMask;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, GroundMask))
        {
            string terrainType = hit.collider.gameObject.tag;
            switch (terrainType)
            {
                default:
                    speed = 12f;
                    break;
                case "low":
                    speed = 3f;
                    break;
                case "high":
                    speed = 20f;
                    break;
            }
        }
    }
} 

