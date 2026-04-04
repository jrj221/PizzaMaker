using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _offset;
    private float _pitch;
    private float _yaw;

    private void LateUpdate()
    {
        MoveCamera();
        RotateCameraAndPlayer();
    }

    private void MoveCamera()
    {
        transform.position = _player.transform.position + _offset;
    }

    private void RotateCameraAndPlayer()
    {
        /*
        Setting both cam yaw and pitch causes gimbal lock, so we do pitch on camera, but yaw on player, which moves
        cam anyway since it is a child of the player
        */
        
        // Cam and Player Yaw (left and right)
        _yaw += InputManager.Instance.DeltaCameraMovement.x;
        _player.transform.rotation = Quaternion.Euler(0f, _yaw, 0f);
        
        // Cam Pitch (up and down)
        _pitch -= InputManager.Instance.DeltaCameraMovement.y;
        _pitch = Mathf.Clamp(_pitch, -90, 90);
        transform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
    }
}
