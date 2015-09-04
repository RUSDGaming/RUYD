using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

	public Rigidbody body;

	private float
		speed = 100;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float incr = horizontal * Time.deltaTime * speed;

		Debug.Log ("ncr" + incr);
		body.AddForce (new Vector3 (incr, 0, 0), ForceMode.Impulse);
		//body.v

	}
}
