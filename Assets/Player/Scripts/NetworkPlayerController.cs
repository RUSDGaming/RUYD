using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayerController : NetworkBehaviour
{


	PlayerController playerController;

	void Start ()
	{
		playerController = GetComponent<PlayerController> ();

	}


	// Update is called once per frame
	void Update ()
	{
		if (isLocalPlayer) {
			playerController.checkControls ();
		}
	}
	
	void FixedUpdate ()
	{
		playerController.DoPhysics ();
	}
}
