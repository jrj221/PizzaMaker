using Interactions;
using UnityEngine;

public class PizzaInteraction : MonoBehaviour, IInteract
{
    public void Interact(GameObject playerHeldItem)
    {
        if (playerHeldItem != null) return; // Can't pick up 
        Debug.Log("Gonna pick up pizza");
        EventBus.Trigger("PickupItem", transform.gameObject );
    }
}
