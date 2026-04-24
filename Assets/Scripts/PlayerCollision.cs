using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1f;

        // Desativar movimento
        thePlayer.GetComponent<PlayerMovement>().enabled = false;

        // Tocar animação de morte
        playerAnim.GetComponent<Animator>().Play("Die");

        SceneManager.LoadScene(2);
    }
}
