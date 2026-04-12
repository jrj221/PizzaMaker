using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    public static OrderGenerator Instance { get; private set; }
    [SerializeField] private OrderData _orderData;

    private void Awake()
    {
        Instance = this;
    }

    public (string, List<string>) GenerateOrder()
    {
        string orderSauce = _orderData.GetSauce();
        List<string> orderToppings = _orderData.GetToppings();
        
        return (orderSauce, orderToppings);
    }
}
