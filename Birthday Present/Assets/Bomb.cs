using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject particles;
    public float radius;
    public float explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Instantiate(particles, collision.GetContact(0).point, Quaternion.identity);
            FindObjectOfType<TimeWarp>().SlowDownTime(0.5f, 2);
            Detonate();
        }

    }


    void Detonate()
    {
        //GameManager.instance.GameOver();

        Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (!collider.transform.CompareTag("Player"))
                {
                    rb.AddExplosionForce(1500, transform.position, 3);
                    rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
                }
            }

        }

        //GameManager.instance.GameOver();
    }
}
