using Interactions;
using UnityEngine;

public class IngredientStationInteraction : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject ingredientPrefab;
    
    public void Interact(GameObject playerHeldItem)
    {
        if (playerHeldItem != null) return; // Can't interact while holding something
        GameObject ingredient = Instantiate(ingredientPrefab, transform.position, transform.rotation);
        EventBus.Trigger("PickupItem", ingredient);
        // There's some duplication here and with pizza, all things that only interact to pickup might be unified somehow
    }
}
