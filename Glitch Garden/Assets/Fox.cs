using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{

    private Animator _animator;

    private Attacker _attacker;
    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _attacker = GetComponent<Attacker>();

    }

    // Update is called once per frame
    void Update()
    {

        _attacker.StrikeCurrentTarget(50f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (!obj.GetComponent<Defender>())
            return;

        if (obj.GetComponent<Stone>())
        {
            _animator.SetTrigger("isJumping");
        }
        else
        {
            _animator.SetTrigger("isAttacking");
            _attacker.Attack(obj);

        }

        Debug.Log("Fox collided with " + other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<Stone>())
        {
            _animator.SetBool("isJumping", false);
        }
    }
}
