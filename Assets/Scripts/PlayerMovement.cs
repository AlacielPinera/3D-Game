using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }


    void Update() {
         // Read/Gets input from keyboard
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move the sheep using physics
        Vector3 movement = new Vector3(moveX * moveSpeed, rb.linearVelocity.y, moveZ * moveSpeed);
        rb.linearVelocity = movement;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * 2f * Time.deltaTime;
        }

        // Rotate the sheep to face movement direction
        Vector3 moveDir = new Vector3(moveX, 0, moveZ);
        if (moveDir != Vector3.zero) {
            transform.forward = moveDir;
        }


    }

    // Ground detection
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") ||
        collision.gameObject.CompareTag("Spawn Point")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") ||
        collision.gameObject.CompareTag("Spawn Point")) {
            isGrounded = false;
        }
    }
}