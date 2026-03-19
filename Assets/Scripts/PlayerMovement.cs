using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10;
    public float speedHorizontal = 10;
    public float rightLimit = 10.5f;
    public float leftLimit = -10.5f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return; 

        // Esquerda
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            if (transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speedHorizontal);
            }
        }

        // Direita 
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {   
            if (transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speedHorizontal);
            }
        }
    }
}