using UnityEngine;
using TMPro;

public class PizzaUI : MonoBehaviour
{
    public TextMeshProUGUI pizzaText;
    [SerializeField] AudioSource collect;
    private int lastCount = 0;

    public static int pizzasTotal = 0;

    public void UpdatePizzaCount(int count)
    {

        pizzasTotal = count;

        pizzaText.text = count.ToString("D3");

        if (count > lastCount && collect != null)
        {
            collect.Play();
        }
    }

    public void SoundCollect()
    {
        collect.Play();
    }
}
