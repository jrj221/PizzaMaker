using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    private PizzaOrder _customerOrder;
    private PizzaOrder _preparedOrder;

    private void Awake()
    {
        _customerOrder = GetComponent<PizzaOrder>();
    }

    private void Start()
    {
        (string sauce, List<string> toppings) = OrderGenerator.Instance.GenerateOrder();
        _customerOrder.AddSauce(sauce);
        foreach (string topping in toppings)
        {
            _customerOrder.AddTopping(topping);
        }
        _customerOrder.FinishOrder();
        Debug.Log(_customerOrder);
    }

    private void OnTriggerEnter(Collider other)
    {
        PizzaOrder otherOrder = other.gameObject.GetComponent<PizzaOrder>();
        if (!otherOrder) return;
        if (!otherOrder.OrderDone) return;
        
        _preparedOrder = other.gameObject.GetComponent<PizzaOrder>();
        int pizzaRating = OrderVerifier.Instance.Verify(_preparedOrder, _customerOrder);
        Debug.Log("Your pizza score: " + pizzaRating);
    }
}
