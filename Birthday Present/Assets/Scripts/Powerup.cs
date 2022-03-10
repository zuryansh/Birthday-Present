using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float slowdownFactor;
    public float time;


    public enum Type
    {
        Time  , Coin
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
            
            else if(type == Type.Coin)
            {
                GameManager.instance.coins++;
            }

            Destroy(gameObject);
        }
    }

    

}
