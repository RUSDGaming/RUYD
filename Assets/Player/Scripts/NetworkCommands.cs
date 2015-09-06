using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkCommands : NetworkBehaviour
{


	public PlayerController playerController;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	[Command]
	public void CmdIChangedLevel ()
	{
		RpcResetPlayer ();
	}

	[ClientRpc]
	public void RpcResetPlayer ()
	{
		GameObject go = GameObject.FindGameObjectWithTag ("Respawn");
		if (go != null) {
			playerController.respawn = go.transform;
			transform.position = playerController.respawn.position;
			playerController.velX = 0f;
			playerController.velY = 0f;
		}
	}

}
