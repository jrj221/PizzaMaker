using System;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOrder : MonoBehaviour
{
    private Order _pizzaOrder;
    private Dictionary<string, GameObject> _ingredients;
    [SerializeField] private GameObject _pepperoni;

    private void Awake()
    {
        _ingredients = new Dictionary<string, GameObject>()
        {
            {"Pepperoni",_pepperoni},
        };
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ingredient")) return;
        
        AddIngredient(other.gameObject);
    }

    private void AddIngredient(GameObject ingredient)
    {
        string ingredientName = ingredient.transform.name.Replace("(Clone)", "");
        _ingredients.TryGetValue(ingredientName, out GameObject ingredientObj);
        if (ingredientObj)
        {
            if (ingredientName.Contains("Sauce"))
            {
                _pizzaOrder.addSauce(ingredientName);
            }
            else
            {
                _pizzaOrder.addTopping(ingredientName);
            }
            ingredientObj.SetActive(true);
            Destroy(ingredientObj);
        }
        else
        {
            Debug.Log(ingredientName + " is not a valid ingredient");
        }
    }
}
