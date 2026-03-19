using UnityEngine;
using UnityEngine.InputSystem; 
public class PlayerMovement : MonoBehaviour
{
    public float velocidadeHorizontal = 10;

    void Update()
    {
        // Guardar a direcao do movimento
        Vector3 movimento = Vector3.zero;

        // Input System
        var teclado = Keyboard.current;

        if (teclado == null) return; 

        // Frente
        if (teclado.wKey.isPressed || teclado.upArrowKey.isPressed)
        {
            movimento += Vector3.forward;
        }

        // Tras
        if (teclado.sKey.isPressed || teclado.downArrowKey.isPressed)
        {
            movimento += Vector3.back;
        }

        // Esquerda
        if (teclado.aKey.isPressed || teclado.leftArrowKey.isPressed)
        {
            movimento += Vector3.left;
        }

        // Direita
        if (teclado.dKey.isPressed || teclado.rightArrowKey.isPressed)
        {
            movimento += Vector3.right;
        }

        // Aplica o movimento final
        transform.Translate(movimento * Time.deltaTime * velocidadeHorizontal);
    }
}
