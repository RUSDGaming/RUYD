using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour
{

	public bool Vertical = false;
	public bool Horizontal = false;
	public float deltaH = 1;
	public float deltaV = 1;

	Vector3 startPos;
	// Use this for initialization
	void Start ()
	{
		startPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate ()
	{
		Vector3 pos = new Vector3 ();
		float h = 0;
		float v = 0;
		if (Horizontal) {
			h = Mathf.Sin (Time.timeSinceLevelLoad) * deltaH;
		}
		if (Vertical) {
			v = Mathf.Sin (Time.timeSinceLevelLoad) * deltaV;
		}

		pos = new Vector3 (startPos.x + h, startPos.y + v, transform.position.z);
		transform.position = pos;

	}
}
