using UnityEngine;

namespace Interactions
{
    public interface IInteract
    {
        public void Interact(GameObject playerHeldItem);

        public GameObject GetOutlinePart(); // This GameObject needs to be on the "Supports Outline" layer
    }
}