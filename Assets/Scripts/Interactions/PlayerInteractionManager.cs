using Interactions;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _interactDistance;
    private GameObject _heldItem;
    private GameObject _focusedItem;

    private void Start()
    {
        EventBus.Subscribe(GameEvents.OnInteract, Interact);
        EventBus.Subscribe<GameObject>(GameEvents.PickupItem, Pickup);
        EventBus.Subscribe<string>(GameEvents.OnInteract, Test1);
        EventBus.Subscribe<string>(GameEvents.OnInteract, Test2);
        EventBus.Subscribe<int>(GameEvents.OnInteract, Test3);
    }

    private void Update()
    {
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _interactDistance))
        {
            // You aren't looking at anything
            RemoveOutline(_focusedItem);
            _focusedItem = null;
            return;
        }

        if (!hit.transform.gameObject.layer.Equals(LayerMask.NameToLayer("Supports Outline"))) return; // Don't outline object that doesn't support it
        if (hit.transform.gameObject.Equals(_focusedItem)) return; // Return if you're looking at the same thing as last frame
        
        GameObject prevFocusedItem = _focusedItem;
        _focusedItem = hit.transform.gameObject;
        RemoveOutline(prevFocusedItem);
        AddOutline(_focusedItem);
    }

    private void AddOutline(GameObject item)
    {
        item.layer = LayerMask.NameToLayer("Currently Outlined");
        // Should different objects receive different colored outlines?
    }

    private void RemoveOutline(GameObject item)
    {
        if (!item) return; // Don't remove outline if item is null
        
        item.layer = LayerMask.NameToLayer("Supports Outline");
    }

    private void Interact()
    {
        var interactable = _focusedItem?.transform.gameObject.GetComponent<IInteract>();
        interactable?.Interact(_heldItem);
    }

    private void Pickup(GameObject obj)
    {
        
    }
}
