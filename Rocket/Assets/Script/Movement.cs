using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

	Rigidbody rb;

	[SerializeField] float thrust = 1.0f;
	float rotationSpeed = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
		processInput();        
    }

	void processInput()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.D))
		{
			ApplyRotation(-rotationSpeed);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			ApplyRotation(rotationSpeed);
		}
	}


	void ApplyRotation(float rotationThisFrame)
	{
		rb.freezeRotation = true; // freezing rotation so we can manually rotate
		transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime * rotationSpeed);
		rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
	}
}
