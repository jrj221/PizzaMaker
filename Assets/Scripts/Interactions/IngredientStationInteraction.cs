using Interactions;
using UnityEngine;

public class IngredientStationInteraction : MonoBehaviour, IInteract
{
    [SerializeField] private string flavorName;
    [Header("Change ONLY in the base prefab")]
    [SerializeField] private IngredientDatabase_SO flavorDatabase;
    [SerializeField] private GameObject containerIceCreamPrefab;
    [SerializeField] private GameObject containerOutlineIceCreamPrefab;
    [SerializeField] private GameObject scoopIceCreamPrefab;
    private Material _flavorMaterial;


    public void Start()
    {
        _flavorMaterial = flavorDatabase.GetIngredient(flavorName).Material;
        containerIceCreamPrefab.GetComponent<Renderer>().material = _flavorMaterial;
        containerOutlineIceCreamPrefab.GetComponent<Renderer>().material = _flavorMaterial;
    }
    
    public void Interact(GameObject playerHeldItem)
    {
        if (playerHeldItem != null) return; // Can't interact while holding something
        GameObject ingredient = Instantiate(scoopIceCreamPrefab, transform.position, transform.rotation);
        ingredient.GetComponent<Renderer>().material = _flavorMaterial;
        EventBus.Trigger("PickupItem", ingredient);
        // There's some duplication here and with pizza, all things that only interact to pickup might be unified somehow
    }

    public GameObject GetOutlinePart()
    {
        return containerOutlineIceCreamPrefab;
    }
}
