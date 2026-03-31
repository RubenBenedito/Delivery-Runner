using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnim;
    [SerializeField] GameOverUI gameOverUI;

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

        // Desativar movimento
        thePlayer.GetComponent<PlayerMovement>().enabled = false;

        // Tocar animação de morte
        playerAnim.GetComponent<Animator>().Play("Die");

        // Mostrar texto "Morreu"
        gameOverUI.ShowGameOver();
    }
}
