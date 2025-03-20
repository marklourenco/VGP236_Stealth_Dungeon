using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    // Refs
    Rigidbody rb;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Transform playerRot;

    // Movement
    public float moveForce = 10.0f;
    public float runMoveForce = 0.5f;
    private float savedMoveForce = 0.05f;
    public float maxSpeed = 5.0f;
    public float drag = 0.9f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = drag;

        GameController.Instance.SetPlayerStartPosition(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            savedMoveForce = moveForce;
            moveForce = runMoveForce;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveForce = savedMoveForce;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(moveX, 0.0f, moveZ).normalized;

        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetFloat("Speed", moveZ);

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetFloat("Speed", -moveZ);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("Speed", moveX);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("Speed", -moveX);
        }
        else if (moveZ == 0.0f && moveX == 0.0f)
        {
            animator.SetFloat("Speed", 0.0f);
        }

        if (moveZ > 0.0f)
        {
            playerRot.rotation = Quaternion.Euler(playerRot.rotation.eulerAngles.x, 0.0f, playerRot.rotation.eulerAngles.z);
        }
        else if (moveZ < 0.0f)
        {
            playerRot.rotation = Quaternion.Euler(playerRot.rotation.eulerAngles.x, 180.0f, playerRot.rotation.eulerAngles.z);
        }
        else if (moveX > 0.0f)
        {
            playerRot.rotation = Quaternion.Euler(playerRot.rotation.eulerAngles.x, 90.0f, playerRot.rotation.eulerAngles.z);
        }
        else if (moveX < 0.0f)
        {
            playerRot.rotation = Quaternion.Euler(playerRot.rotation.eulerAngles.x, -90.0f, playerRot.rotation.eulerAngles.z);
        }

        Debug.Log(animator.GetFloat("Speed"));

        if (rb.angularVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveInput * moveForce, ForceMode.Impulse);
        }
    }
}
