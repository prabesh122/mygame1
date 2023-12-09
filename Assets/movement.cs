namespace Mechanics
{
    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        public float walkSpeed = 3.0f;
        public float sprintSpeed = 6.0f;
        public float jumpForce = 8.0f;

        private bool isGrounded;
        private float speed;

        private Rigidbody rb;
        private BoxCollider boxCollider;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            boxCollider = GetComponent<BoxCollider>();
            speed = walkSpeed; // Initial speed is walking speed
        }

        void Update()
        {
            // Check if the player is grounded
            isGrounded = Physics.Raycast(transform.position, Vector3.down, boxCollider.bounds.extents.y + 0.1f);

            // Call the Move method
            Move();

            // Jumping
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }

            // Sprinting
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
            }
            else
            {
                speed = walkSpeed;
            }
        }

        public void Move()
        {
            // Player Movement
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(horizontalMovement, 0, verticalMovement).normalized;

            // Set the velocity based on the input and speed
            rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
        }
    }
}
