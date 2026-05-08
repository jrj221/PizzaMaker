using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ingredient
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Material _material;

    public string Name => _name;
    public GameObject Prefab => _prefab;
    public Material Material => _material;
}

[CreateAssetMenu(fileName = "DatabaseSO", menuName = "Scriptable Objects/Object Database")]
public class IngredientDatabase_BaseSO : ScriptableObject
{
    [SerializeField] public List<Ingredient> Ingredients;

    public Ingredient GetIngredient(string ingredientName)
    {
        return Ingredients.Find(x => x.Name == ingredientName);
    }
}
