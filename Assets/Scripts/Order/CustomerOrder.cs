using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    private PizzaOrder _customerOrder;

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
}
