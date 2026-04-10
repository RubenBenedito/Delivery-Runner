using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10;
    public float laneWidth = 4.0f;
    public float maxSpeed = 35f;        
    public float acceleration = 0.2f;
    public int currentLane = 2;

    public int pizzasApanhadas = 0; 

    public PizzaUI ui; // Referencia para o script de UI

    void Update()
    {
        
        if (playerSpeed < maxSpeed)
        {
            playerSpeed += acceleration * Time.deltaTime;
        }

        // Frente
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Esquerda 
        if (keyboard.aKey.wasPressedThisFrame || keyboard.leftArrowKey.wasPressedThisFrame)
        {
            if (currentLane > 1)
            {
                currentLane--;
            }
        }

        // Direita 
        if (keyboard.dKey.wasPressedThisFrame || keyboard.rightArrowKey.wasPressedThisFrame)
        {
            if (currentLane < 3)
            {
                currentLane++;
            }
        }

        // Lane 1 -> (1 - 2) * 4 - 7.76 = -11.76
        // Lane 2 -> (2 - 2) * 4 - 7.76 = -7.76 
        // Lane 3 -> (3 - 2) * 4 - 7.76 = -3.76
        float targetX = ((currentLane - 2) * laneWidth) - 7.76f;

        Vector3 newPos = transform.position;
        newPos.x = Mathf.MoveTowards(newPos.x, targetX, Time.deltaTime * 40f);
        transform.position = newPos;
    }


    // Apanhar pizza
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            pizzasApanhadas++;
            Destroy(other.gameObject);

            // Atualizar UI
            if (ui != null)
            {
                ui.UpdatePizzaCount(pizzasApanhadas);
            }
        }
    }
}
