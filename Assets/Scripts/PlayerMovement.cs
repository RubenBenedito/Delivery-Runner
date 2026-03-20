using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10;
    public float laneWidth = 10.0f; 
    public int currentLane = 1;    

    void Update()
    {
        // Movimento para frente
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        // ESQUERDA - Mudamos para wasPressedThisFrame (clique único)
        if (keyboard.aKey.wasPressedThisFrame || keyboard.leftArrowKey.wasPressedThisFrame)
        {
            if (currentLane > 0)
            {
                currentLane--;
            }
        }

        // DIREITA - Mudamos para wasPressedThisFrame (clique único)
        if (keyboard.dKey.wasPressedThisFrame || keyboard.rightArrowKey.wasPressedThisFrame)
        {
            if (currentLane < 2)
            {
                currentLane++;
            }
        }

        // Cálculo exato:
        // Se currentLane = 0 -> (0 - 1) * 7 = -7
        // Se currentLane = 1 -> (1 - 1) * 7 = 0
        // Se currentLane = 2 -> (2 - 1) * 7 = 7
        float targetX = (currentLane - 1) * laneWidth;

        // Movimento Suave
        Vector3 newPos = transform.position;
        // Aumentei de 15f para 20f para ser mais responsivo (estilo Subway Surfers)
        newPos.x = Mathf.MoveTowards(newPos.x, targetX, Time.deltaTime * 25f);
        transform.position = newPos;
    }
}