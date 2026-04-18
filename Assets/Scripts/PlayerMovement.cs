using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float laneWidth = 4.0f;
    public float maxSpeed = 35f;
    public float acceleration = 0.2f;
    public int currentLane = 2;

    public float jumpForce = 15f;
    private bool isGrounded = true;

    public int pizzasApanhadas = 0;
    public PizzaUI ui;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Aceleração
        if (playerSpeed < maxSpeed)
            playerSpeed += acceleration * Time.deltaTime;

        // Movimento para a frente
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Mudar de lane
        if (keyboard.aKey.wasPressedThisFrame || keyboard.leftArrowKey.wasPressedThisFrame)
            if (currentLane > 1) currentLane--;

        if (keyboard.dKey.wasPressedThisFrame || keyboard.rightArrowKey.wasPressedThisFrame)
            if (currentLane < 3) currentLane++;

        // Salto
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Movimento lateral suave
        float targetX = ((currentLane - 2) * laneWidth) - 7.76f;
        Vector3 newPos = transform.position;
        newPos.x = Mathf.MoveTowards(newPos.x, targetX, Time.deltaTime * 40f);
        transform.position = newPos;
    }

    // Detetar chão
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Chao"))
        {
            isGrounded = true;
        }
    }

    // Apanhar pizza
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            pizzasApanhadas++;
            Destroy(other.gameObject);

            if (ui != null)
                ui.UpdatePizzaCount(pizzasApanhadas);
        }
    }
}
