using System.Collections.Generic;
using UnityEngine;

public class PizzaOrderHandler : MonoBehaviour
{
    private PizzaOrder _pizzaOrder;
    [SerializeField] private float _reboundForce;
    private Dictionary<string, GameObject> _ingredients;
    [SerializeField] private GameObject _pepperoni;
    [SerializeField] private GameObject _olives;
    [SerializeField] private GameObject _sausage;
    [SerializeField] private GameObject _bacon;
    [SerializeField] private GameObject _lemons;
    [SerializeField] private GameObject _jalapenos;
    [SerializeField] private GameObject _cheese;
    [SerializeField] private GameObject _whiteSauce;
    [SerializeField] private GameObject _redSauce;
    [SerializeField] private GameObject _pestoSauce;

    private void Awake()
    {
        _pizzaOrder = GetComponent<PizzaOrder>();
        
        _ingredients = new Dictionary<string, GameObject>()
        {
            {"Pepperoni",_pepperoni},
            {"Sausage",_sausage},
            {"Olives",_olives},
            {"Bacon", _bacon},
            {"Lemons", _lemons},
            {"Jalapenos", _jalapenos},
            {"Cheese", _cheese},
            {"White Sauce", _whiteSauce},
            {"Red Sauce", _redSauce},
            {"Pesto Sauce", _pestoSauce}
        };
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ingredient")) return;

        if (!AddIngredient(other.gameObject)) // Ingredient not added
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(-other.contacts[0].normal * _reboundForce, ForceMode.Impulse);
        }
    }

    private bool AddIngredient(GameObject ingredient)
    {
        string ingredientName = ingredient.transform.name.Replace("Ingredient_", "").Replace("(Clone)", "");
        Debug.Log(ingredientName);
        _ingredients.TryGetValue(ingredientName, out GameObject toppingObj);
        if (toppingObj)
        {
            if (ingredientName.Contains("Sauce"))
            {
                if (!_pizzaOrder.AddSauce(ingredientName)) return false; // Ingredient not added
            }
            else
            {
                if (!_pizzaOrder.AddTopping(ingredientName)) return false;
            }
            toppingObj.SetActive(true);
            Destroy(ingredient);
        }
        else
        {
            Debug.Log(ingredientName + " is not a valid ingredient");
            return false;
        }

        return true; // Ingredient added successfully. 
    }
}
