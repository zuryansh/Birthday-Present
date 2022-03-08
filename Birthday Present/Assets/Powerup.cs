using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float slowdownFactor;
    public float time;

    public float radius;
    public float explosionForce;

    public enum Type
    {
        Time , Bomb , Coin
    }
    public Type type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (type == Type.Time)
            {

                FindObjectOfType<TimeWarp>().SlowDownTime(slowdownFactor, time);
            }
            else if(type == Type.Bomb)
            {
                Detonate();
            }
            else if(type == Type.Coin)
            {
                GameManager.instance.coins++;
            }

            Destroy(gameObject);
        }
    }

    void Detonate()
    {
        //GameManager.instance.GameOver();

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
                rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            }

        }

        //GameManager.instance.GameOver();
    }

}
