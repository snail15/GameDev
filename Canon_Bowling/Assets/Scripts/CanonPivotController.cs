using UnityEngine;

public class CanonPivotController : MonoBehaviour
{


    private enum RotationState
    {
        Idle,
        Vertical,
        Horizontal,
        Ready
    }

    private RotationState _rotationState = RotationState.Idle;

    public float vertialRotateSpeed = 360f;
    public float horizontalRotateSpeed = 360f;

    public BallShooter BallShooter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetCanonAngle();
    }

    private void SetCanonAngle()
    {
        switch (_rotationState)
        {
            case RotationState.Idle:
                if (Input.GetButtonDown("Fire1"))
                {
                    _rotationState = RotationState.Horizontal;
                }
                break;
            case RotationState.Horizontal:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    _rotationState = RotationState.Vertical;
                }
                break;
            case RotationState.Vertical:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(-vertialRotateSpeed * Time.deltaTime, 0, 0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    _rotationState = RotationState.Ready;
                    BallShooter.enabled = true;
                }
                break;
            case RotationState.Ready:
                break;
        }

    }

    void OnEnable()
    {
        transform.rotation = Quaternion.identity;
        _rotationState = RotationState.Idle;
        BallShooter.enabled = false;

    }
}
