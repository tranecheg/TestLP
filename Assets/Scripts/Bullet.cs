using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameSettings gameSettings;
    private float enemyForce = 2f;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * gameSettings.bulletForce, gameSettings.forceMode);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            other.transform.GetComponent<Rigidbody>().AddForceAtPosition(other.transform.position.normalized, transform.position);
            other.transform.GetComponent<Ragdoll>().ActivateRagdoll();
            other.transform.GetComponent<Ragdoll>().ApplyForce(transform.position * enemyForce);
            Destroy(other.transform.gameObject, 3);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);

    }
}
