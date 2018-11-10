using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 1f)]
    [SerializeField]
    float MoveSpeed;

    private GameObject _currentTarget;

    private Animator _animator;
    // Use this for initialization
    void Start()
    {
        //Rigidbody2D myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        //myRigidbody2D.isKinematic = true;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * MoveSpeed);
        if (!_currentTarget)
            _animator.SetBool("isAttacking", false);
    }

    public void SetMovingSpeed(float speed)
    {
        MoveSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (_currentTarget)
        {
            Health health = _currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        _currentTarget = obj;

    }
}
