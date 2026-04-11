using Interactions;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _interactDistance;
    private GameObject _heldItem;

    private void Start()
    {
        EventBus.Subscribe(GameEvents.OnInteract, Interact);
    }

    private void Interact(object param)
    {
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _interactDistance, Color.red, 3f);
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit,
                _interactDistance)) return;
        var interactable = hit.transform.gameObject.GetComponent<IInteract>();
        interactable?.Interact(_heldItem);
    }
}
