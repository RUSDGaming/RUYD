using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DebugPlayerController : MonoBehaviour
{
	PlayerController pc;

	// Use this for initialization
	void Start ()
	{
		pc = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		pc.checkControls ();
	}

	void FixedUpdate ()
	{
		pc.DoPhysics ();
	}
}
