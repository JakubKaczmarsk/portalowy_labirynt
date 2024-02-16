using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    [SerializeField]
    public float speed = 12f;
    public float speedMultiplayer { get; private set; } = 1f;
    private CharacterController controller;

    public Transform groundCheck;
    public LayerMask groundMask;
       


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
        CheckGround();
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    speed = 12f * speedMultiplayer;
                    break;
                case "Low":
                    speed = 3f * speedMultiplayer;
                    break;
                case "High":
                    speed = 20f * speedMultiplayer;
                    break;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Pickup")
        {
            hit.gameObject.GetComponent<Pickup>().Picked();
        }
    }
}
