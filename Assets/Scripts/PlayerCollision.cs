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
        Debug.Log("MORREU!");

        thePlayer.GetComponent<PlayerMovement>().enabled = false;

        playerAnim.GetComponent<Animator>().Play("Die");
        gameOverUI.ShowGameOver();

        SceneManager.LoadScene(0);
    }
}
