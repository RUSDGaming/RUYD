using UnityEngine;
using System.Collections;

public class IsGrounded : MonoBehaviour
{


	public PlayerController playerController;
	public float groundDistance;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	
	}

	void FixedUpdate ()
	{
		CheckDistanceToGround ();
	}

	void CheckDistanceToGround ()
	{
		RaycastHit hit;
		
		if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
			if (hit.distance < groundDistance) {
				playerController.grounded = true;
			} else {
				playerController.grounded = false;
			}


		}
	}

}
