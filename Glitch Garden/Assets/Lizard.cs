using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
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

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (!obj.GetComponent<Defender>())
            return;
        else
        {
            _animator.SetTrigger("isAttacking");
            _attacker.Attack(obj);
        }

        Debug.Log($"{name} collided with {other}");
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
