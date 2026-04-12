using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private string _sauce;
    private List<string> _ingredients;

    public void addSauce(string sauce)
    {
        if (_sauce != "") return; // Can't replace the sauce
        _sauce = sauce;
    }

    public void addTopping(string ingredient)
    {
        _ingredients.Add(ingredient);
    }
}
