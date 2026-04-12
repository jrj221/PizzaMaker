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

    public void AddSauce(string sauce)
    {
        if (OrderDone || Sauce != "") return; // Can't replace the sauce
        Sauce = sauce;
    }

    public void AddTopping(string ingredient)
    {
        if  (OrderDone) return;
        Ingredients.Add(ingredient);
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
