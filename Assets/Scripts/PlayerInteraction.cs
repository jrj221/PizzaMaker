using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    private GameObject _heldItem;

    private void Start()
    {
        EventBus.Subscribe(GameEvents.OnInteract, Interact);
    }

    private void Interact(object param)
    {
        //
    }
}
