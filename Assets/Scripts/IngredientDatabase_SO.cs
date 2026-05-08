using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ingredient
{
    [SerializeField] private string _name;
    [SerializeField] private Material _material;

    public string Name => _name;
    public Material Material => _material;
}

[CreateAssetMenu(fileName = "DatabaseSO", menuName = "Scriptable Objects/Object Database")]
public class IngredientDatabase_SO : ScriptableObject
{
    [SerializeField] public List<Ingredient> Ingredients;

    public Ingredient GetIngredient(string ingredientName)
    {
        return Ingredients.Find(x => x.Name == ingredientName);
    }
}
