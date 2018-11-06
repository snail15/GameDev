using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 1f)]
    [SerializeField]
    float MoveSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * MoveSpeed);
    }
}
