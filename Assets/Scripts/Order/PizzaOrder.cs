using System.Collections.Generic;
using UnityEngine;

public class PizzaOrder :  MonoBehaviour
{
    public string Sauce { get; private set; }
    public List<string> Ingredients { get; private set; }
    public bool OrderDone { get; private set; }

    private void Awake()
    {
        Ingredients = new List<string>();
    }

    public bool AddSauce(string sauce)
    {
        if (OrderDone || Sauce != "") return false; // Can't replace the sauce
        Sauce = sauce;
        return true;
    }

    public bool AddTopping(string ingredient)
    {
        if  (OrderDone) return false;
        Ingredients.Add(ingredient);
        return true;
    }

    public void FinishOrder()
    {
        OrderDone = true;
    }

    public override string ToString()
    {
        return $"SAUCE: {Sauce}\nINGREDIENTS: {string.Join(", ", Ingredients)}";
    }
}
