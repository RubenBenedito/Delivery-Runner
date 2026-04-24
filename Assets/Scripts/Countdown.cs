using UnityEngine;
using TMPro;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public PlayerMovement player;

    private Animator anim;

    void Start()
    {
        player.enabled = false;

        // apanhar o Animator no Player 
        anim = player.GetComponentInChildren<Animator>();

        if (anim != null)
            anim.speed = 0f;   // pausa a animação

        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "Começou!";
        yield return new WaitForSeconds(0.5f);

        countdownText.gameObject.SetActive(false);

        if (anim != null)
            anim.speed = 1f;   // retoma a animação

        player.enabled = true; // começa a correr
    }
}