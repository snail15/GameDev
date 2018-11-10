using UnityEngine;

public class Health : MonoBehaviour
{

    public float HP;

    public void DealDamage(float damage)
    {
        HP -= damage;
        if (HP < 0)
            Destroy(gameObject);
    }
}
