using Interactions;
using UnityEngine;

public class PizzaInteraction : MonoBehaviour, IInteract
{
    public void Interact(GameObject playerHeldItem)
    {
        if (playerHeldItem != null) return; // Can't pick up
        EventBus.Trigger("PickupItem", new {transform.gameObject} );
    }
}
