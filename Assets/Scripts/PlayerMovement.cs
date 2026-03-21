using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10;
    public float laneWidth = 10.0f; 
    public int currentLane = 2;    

    void Update()
    {
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


        // Lane = 1 -> (1 - 2) * 10 = -10 
        // Lane = 2 -> (2 - 2) * 10 =  0 
        // Lane = 3 -> (3 - 2) * 10 =  10 
        float targetX = (currentLane - 2) * laneWidth;

        Vector3 newPos = transform.position;

        newPos.x = Mathf.MoveTowards(newPos.x, targetX, Time.deltaTime * 25f);
        transform.position = newPos;
    }
}