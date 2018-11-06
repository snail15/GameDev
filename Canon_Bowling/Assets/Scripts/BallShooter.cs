using UnityEngine;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour
{
    public CamFollow cam;

    public Rigidbody CanonBall;
    public Transform FirePos;

    public Slider PowerSlider;

    public AudioSource ShootingAudio;
    public AudioClip FireClip;
    public AudioClip ChargingClip;

    public float MinForce = 15f;
    public float MaxForce = 30f;
    public float ChargingTime = 0.75f;

    private float _currentForce;
    private float _chargeSpeed;
    private bool isFired;

    // Use this for initialization
    void Start()
    {
        _chargeSpeed = (MaxForce - MinForce) / ChargingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFired)
            return;

        PowerSlider.value = MinForce;

        if (_currentForce >= MaxForce && !isFired)
        {
            _currentForce = MaxForce;
            Fire();


        }
        else if (Input.GetButtonDown("Fire1") && !isFired)
        {
            _currentForce = MinForce;
            ShootingAudio.clip = ChargingClip;
            ShootingAudio.Play();
        }
        else if (Input.GetButton("Fire1"))
        {
            _currentForce += (_chargeSpeed * Time.deltaTime);
            PowerSlider.value = _currentForce;
        }
        else if (Input.GetButtonUp("Fire1") && !isFired)
        {

            Fire();
        }
    }

    private void Fire()
    {
        PowerSlider.enabled = true;
        Debug.Log("Fire!");
        isFired = true;

        Rigidbody canonBallInstance = Instantiate(CanonBall, FirePos.position, FirePos.rotation);
        canonBallInstance.velocity = _currentForce * FirePos.forward;
        ShootingAudio.clip = FireClip;
        ShootingAudio.Play();

        _currentForce = MinForce;

        cam.SetTarget(canonBallInstance.transform, CamFollow.State.Tracking);
    }

    void OnEnable()
    {
        _currentForce = MinForce;
        PowerSlider.value = MinForce;
        PowerSlider.enabled = true;
        isFired = false;
    }

}
