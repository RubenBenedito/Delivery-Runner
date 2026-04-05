using UnityEngine;
using TMPro;

public class PizzaUI : MonoBehaviour
{
    public TextMeshProUGUI pizzaText;
    [SerializeField] AudioSource collect;

    public void UpdatePizzaCount(int count)
    {
        pizzaText.text = "Pizzas: " + count;
        SoundCollect();
    }

    public void SoundCollect()
    {
        collect.Play();
    }
}
