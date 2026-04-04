using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actions;
    [SerializeField] private InputActionReference _move;
    [SerializeField] private InputActionReference _look;
    [SerializeField] private InputActionReference _interact;
    
    public static InputManager Instance {get ; private set;}
    public Vector2 InputMoveDirection { get; private set; }
    public Vector2 DeltaCameraMovement { get; private set; }
    public bool PressedInteract { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    
    private void OnEnable()
    {
        _actions.Enable();
        _move.action.performed += PerformMove;
        _look.action.performed += PerformLook;
        _interact.action.started += StartInteract;
        _interact.action.canceled += CancelInteract;
    }

    private void OnDisable()
    {
        _actions.Disable();
        _move.action.performed -= PerformMove;
        _look.action.performed -= PerformLook;
        _interact.action.started -= StartInteract;
        _interact.action.canceled -= CancelInteract;
    }

    private void PerformMove(InputAction.CallbackContext ctx)
    {
        InputMoveDirection = ctx.ReadValue<Vector2>();
    }

    private void PerformLook(InputAction.CallbackContext ctx)
    {
        DeltaCameraMovement = ctx.ReadValue<Vector2>();
    }

    private void StartInteract(InputAction.CallbackContext ctx)
    {
        PressedInteract = true;
    }

    private void CancelInteract(InputAction.CallbackContext ctx)
    {
        PressedInteract = false;
    }
}
