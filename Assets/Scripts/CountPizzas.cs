using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PizzaUI.pizzasTotal.ToString("D3");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
