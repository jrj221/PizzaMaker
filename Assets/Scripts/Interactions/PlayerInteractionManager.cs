using Interactions;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _interactDistance;
    [SerializeField] private float _throwForce;
    private GameObject _heldItem;
    [SerializeField] private Transform _holdPoint;
    private GameObject _focusedItem;

    private void Start()
    {
        EventBus.Subscribe(GameEvents.OnInteract, Interact);
        EventBus.Subscribe<GameObject>(GameEvents.PickupItem, Pickup);
        EventBus.Subscribe(GameEvents.ThrowItem, Throw);
    }

    private void Update()
    {
        ManageObjectOutlines();
    }

    private void ManageObjectOutlines()
    {
        // Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _interactDistance, Color.red);
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _interactDistance))
        {
            // You aren't looking at anything
            RemoveOutline(_focusedItem);
            _focusedItem = null;
            return;
        }
        
        if (hit.transform.gameObject.Equals(_focusedItem)) return; // Return if you're looking at the same thing as last frame
        
        RemoveOutline(_focusedItem);
        _focusedItem = null;
        
        if (!hit.transform.gameObject.layer.Equals(LayerMask.NameToLayer("Supports Outline"))) return; // Don't outline object that doesn't support it
        _focusedItem = hit.transform.gameObject;
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
        Debug.Log(interactable);
        interactable?.Interact(_heldItem);
    }

    private void Pickup(GameObject obj)
    {
        _heldItem = obj;
        obj.transform.SetParent(_holdPoint);
        var objRigidbody = obj.GetComponent<Rigidbody>();
        objRigidbody.useGravity = false;
        objRigidbody.linearVelocity = Vector3.zero;
        objRigidbody.isKinematic = true;
        objRigidbody.detectCollisions = false;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
    }

    private void Throw()
    {
        if (!_heldItem) return; // Nothing to throw
        
        GameObject throwItem = _heldItem;
        _heldItem = null;
        
        throwItem.transform.SetParent(null);
        throwItem.GetComponent<BoxCollider>().enabled = true;
        var throwRigidbody = throwItem.GetComponent<Rigidbody>();
        throwRigidbody.detectCollisions = true;
        throwRigidbody.useGravity = true;
        throwRigidbody.isKinematic = false;
        throwRigidbody.AddForce(_throwForce * _camera.transform.forward, ForceMode.Impulse);
    }
}
