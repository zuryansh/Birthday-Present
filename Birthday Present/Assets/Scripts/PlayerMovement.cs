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
	public float mobileForce = 50;
	public float mobileLimit;

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
			Debug.Log("RIGHT");
			TurnRight(sidewaysForce);	
		}

		if (Input.GetKey("a")) 
		{
			Debug.Log("LEFT");

			TurnLeft(sidewaysForce);
		}

		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.position.x > Screen.width / 2)
			{
				Debug.Log("RIGHT");

				TurnRight(sidewaysForce);
			}
			else if (touch.position.x < Screen.width / 2)
			{
				Debug.Log("LEFT");

				TurnLeft(sidewaysForce);
			}

		}
	}

	void TurnLeft(float force)
	{
		rb.AddForce(-force * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);

	}
	void TurnRight(float force)
	{
		rb.AddForce(force * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);

	}

}
