using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public enum State
    {
        Idle,
        Ready,
        Tracking
    }

    private State state
    {
        set
        {
            switch (value)
            {
                case State.Idle:
                    _targetZoom = _readyZoom;
                    break;
                case State.Ready:
                    _targetZoom = _shotZoom;
                    break;
                case State.Tracking:
                    _targetZoom = _trackingZoom;
                    break;
            }
        }
    }

    private Transform _target;
    public float lagTime = 0.2f;
    private Vector3 _movingVelocity;
    private Vector3 _targetPosition;

    private Camera _camera;

    private float _targetZoom = 5f;

    private float _readyZoom = 14.5f;

    private float _shotZoom = 5f;

    private float _trackingZoom = 10f;

    private float _zoomSpeed;
    // Use this for initialization

    void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
        state = State.Idle;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Move()
    {
        _targetPosition = _target.transform.position;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, _targetPosition, ref _movingVelocity, lagTime);

        transform.position = smoothPosition;

    }

    void Zoom()
    {
        float smoothZoomSize = Mathf.SmoothDamp(_camera.orthographicSize, _targetZoom, ref _zoomSpeed, lagTime);
        _camera.orthographicSize = smoothZoomSize;
    }

    void FixedUpdate()
    {
        if (_target != null)
        {
            Move();
            Zoom();
        }
    }

    void Reset()
    {
        state = State.Idle;
    }

    public void SetTarget(Transform newTarget, State newState)
    {
        _target = newTarget;
        state = newState;
    }
}
