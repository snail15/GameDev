using UnityEngine;

public class CubeController : MonoBehaviour
{

    public int score;
    public float hp;
    public ParticleSystem explosionParticleSystem;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            ParticleSystem instance = Instantiate(explosionParticleSystem, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration);

            GameManager.instance.AddScore(score);

            gameObject.SetActive(false);

        }
    }
}
