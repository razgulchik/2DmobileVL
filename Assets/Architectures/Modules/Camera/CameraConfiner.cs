using UnityEngine;

public class CameraConfiner : MonoBehaviour
{
    private BoxCollider2D _confinerCollider;
    private Bounds _bounds;
    private Camera _camera;
    private float _camHeight;
    private float _camWidth;

    private void Awake() {
        _camera = Camera.main;
        _confinerCollider = GetComponentInChildren<BoxCollider2D>();
    }

    private void Start() {
        _bounds = _confinerCollider.bounds;
        _camHeight = _camera.orthographicSize;
        _camWidth = _camHeight * _camera.aspect;
    }

    private void LateUpdate() {
        if (_bounds != null) {
            float clampedX = Mathf.Clamp(transform.position.x, _bounds.min.x + _camWidth, _bounds.max.x - _camWidth);
            float clampedY = Mathf.Clamp(transform.position.y, _bounds.min.y + _camHeight, _bounds.max.y - _camHeight);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
