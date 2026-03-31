using UnityEngine;
using TMPro;

public class PizzaUI : MonoBehaviour
{
    public TextMeshProUGUI pizzaText;

    public void UpdatePizzaCount(int count)
    {
        pizzaText.text = "Pizzas: " + count;
    }
}
