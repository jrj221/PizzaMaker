using System.Collections.Generic;
using UnityEngine;

public class PizzaOrder :  MonoBehaviour
{
    private string _sauce;
    private List<string> _ingredients;
    private bool _orderDone;

    private void Awake()
    {
        _ingredients = new List<string>();
    }

    public void AddSauce(string sauce)
    {
        if (_orderDone || _sauce != "") return; // Can't replace the sauce
        _sauce = sauce;
    }

    public void AddTopping(string ingredient)
    {
        if  (_orderDone) return;
        _ingredients.Add(ingredient);
    }

    public void FinishOrder()
    {
        _orderDone = true;
    }

    public override string ToString()
    {
        return $"SAUCE: {_sauce}\nINGREDIENTS: {string.Join(", ", _ingredients)}";
    }
}
