using Interactions;
using UnityEngine;

public class PizzaInteraction : MonoBehaviour, IInteract
{
    public void Interact(GameObject item)
    {
        Debug.Log("Pizza Interact");
    }
}
