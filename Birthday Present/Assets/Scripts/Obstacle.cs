using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject particles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Collision(collision);
        }
    }

    void Collision(Collision collision)
    {
        Debug.Log("COLLISION");
        Instantiate(particles, collision.GetContact(0).point, Quaternion.identity);
        FindObjectOfType<TimeWarp>().SlowDownTime(0.5f, 1);
        Detonate();

        GameManager.instance.GameOver();

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
                rb.AddExplosionForce(1000, transform.position, 3);
                rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            }

        }

        //GameManager.instance.GameOver();
    }
}
