using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderData", menuName = "Scriptable Objects/OrderData")]
public class OrderData : ScriptableObject
{
    public List<string> sauces;
    public List<string> toppings;

    public string GetSauce()
    {
        return sauces[Random.Range(0, sauces.Count)];
    }

    public List<string> GetToppings()
    {
        List<string> randomToppings = new();
        int numToppings = (Random.Range(0f, 1f)) switch
        {
            < 0.05f => 5,
            < 0.1f => 4,
            < 0.3f => 3,
            < 0.7f => 2,
            _ => 1
        };
        
        while (randomToppings.Count < numToppings)
        {
            string randomTopping = toppings[Random.Range(0, toppings.Count)];
            if (randomToppings.Contains(randomTopping)) continue;
            randomToppings.Add(randomTopping);
        }
        
        return  randomToppings;
    }
   
}
