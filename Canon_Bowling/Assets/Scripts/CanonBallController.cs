using UnityEngine;

public class CanonBallController : MonoBehaviour
{

    public ParticleSystem explosionParticleSystem;
    public AudioSource explosionAudio;
    public LayerMask whatIsProp;

    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float lifeSpan = 5f;
    public float explosionRadius = 20f;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifeSpan);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsProp);

        foreach (var collider in colliders)
        {
            Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            CubeController cube = collider.GetComponent<CubeController>();
            float damage = CalculateDamage(collider.transform.position);
            cube.TakeDamage(damage);

        }

        explosionParticleSystem.transform.parent = null;

        explosionParticleSystem.Play();
        explosionAudio.Play();

        GameManager.instance.isRoundActive = false;

        Destroy(explosionParticleSystem.gameObject, explosionParticleSystem.duration);
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explositonToTargetDistance = targetPosition - transform.position;

        float distance = explositonToTargetDistance.magnitude;
        float edgeToCenterDistance = explosionRadius - distance;
        float damagePercentage = edgeToCenterDistance / explosionRadius;

        float calculatedDamage = maxDamage * damagePercentage;

        //To prevent negative number
        return Mathf.Max(0, calculatedDamage);
    }

    void OnDestroy()
    {
        GameManager.instance.OnBallDestroy();
    }
}
