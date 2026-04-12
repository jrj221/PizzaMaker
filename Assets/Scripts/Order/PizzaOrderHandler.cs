using System.Collections.Generic;
using UnityEngine;

public class PizzaOrderHandler : MonoBehaviour
{
    private PizzaOrder _pizzaOrder;
    private Dictionary<string, GameObject> _ingredients;
    [SerializeField] private GameObject _pepperoni;
    [SerializeField] private GameObject _olives;
    [SerializeField] private GameObject _sausage;

    private void Awake()
    {
        _pizzaOrder = GetComponent<PizzaOrder>();
        
        _ingredients = new Dictionary<string, GameObject>()
        {
            {"Pepperoni",_pepperoni},
            {"Sausage",_sausage},
            {"Olives",_olives}
        };
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ingredient")) return;
        
        AddIngredient(other.gameObject);
    }

    private void AddIngredient(GameObject ingredient)
    {
        string ingredientName = ingredient.transform.name.Replace("Ingredient(Clone)", "");
        _ingredients.TryGetValue(ingredientName, out GameObject toppingObj);
        if (toppingObj)
        {
            if (ingredientName.Contains("Sauce"))
            {
                _pizzaOrder.AddSauce(ingredientName);
            }
            else
            {
                _pizzaOrder.AddTopping(ingredientName);
            }
            toppingObj.SetActive(true);
            Destroy(ingredient);
        }
        else
        {
            Debug.Log(ingredientName + " is not a valid ingredient");
        }
    }
}
