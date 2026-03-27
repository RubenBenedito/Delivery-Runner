using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            MatarJogador();
        }
    }

    void MatarJogador()
    {
        Debug.Log("MORREU!"); 

        GetComponent<PlayerMovement>().enabled = false;
    }
}
