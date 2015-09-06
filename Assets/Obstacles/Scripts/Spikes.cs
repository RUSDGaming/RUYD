using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{

	public Transform startPos;
	// Use this for initialization
	void Start ()
	{

		startPos = GameObject.FindGameObjectWithTag ("Respawn").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			PlayerController pc = other.GetComponent<PlayerController> ();
			pc.ResetPlayer ();

			AudioSource audio = other.GetComponent<AudioSource> ();
			audio.Play ();
		}
	}

}
