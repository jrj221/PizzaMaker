using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actions;
    [SerializeField] private InputActionReference _move;
    [SerializeField] private InputActionReference _look;
    
    public static InputManager Instance {get ; private set;}
    public Vector2 InputActionMove { get; private set; }
    public Vector2 DeltaCameraMovement { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    
    private void OnEnable()
    {
        _actions.Enable();
        _move.action.performed += PerformMove;
        _look.action.performed += PerformLook;
    }

    private void OnDisable()
    {
        _actions.Disable();
        _move.action.performed -= PerformMove;
        _look.action.performed -= PerformLook;
    }

    private void PerformMove(InputAction.CallbackContext ctx)
    {
        InputActionMove = ctx.ReadValue<Vector2>();
    }

    private void PerformLook(InputAction.CallbackContext ctx)
    {
        DeltaCameraMovement = ctx.ReadValue<Vector2>();
    }
}
