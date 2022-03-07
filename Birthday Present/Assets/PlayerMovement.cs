using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
	public float forwardForce = 2000f;  
	public float sidewaysForce = 500f;

	public float fowardLimit;
	GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		gameManager = FindObjectOfType<GameManager>();
    }

	
	
	void FixedUpdate()
	{
        if (rb.position.y < 0)
        {
			GameManager.instance.GameOver();
        }


		if(rb.velocity.z<fowardLimit)
			rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))  
		{
			
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a")) 
		{
			
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}

}
