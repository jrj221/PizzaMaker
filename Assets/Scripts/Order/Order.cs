using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private string _sauce;
    private List<string> _ingredients;

    private void Awake()
    {
        _ingredients = new List<string>();
    }

    public void AddSauce(string sauce)
    {
        if (_sauce != "") return; // Can't replace the sauce
        _sauce = sauce;
    }

    public void AddTopping(string ingredient)
    {
        _ingredients.Add(ingredient);
    }
}
