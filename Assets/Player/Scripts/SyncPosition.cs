using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncPosition : NetworkBehaviour
{

	[SyncVar]
	private Vector3
		syncPos;


	public Transform myTransform;
	float LerpRate = 15;


	void FixedUpdate ()
	{
		TransmitPosition ();
		LerpPosition ();
	}

	[ClientCallback]
	void TransmitPosition ()
	{
		if (isLocalPlayer) {
			CmdProvidePositionToServer (myTransform.position);
		}
	}

	[Command]
	void CmdProvidePositionToServer (Vector3 pos)
	{
		syncPos = pos;
	}

	void LerpPosition ()
	{
		if (!isLocalPlayer) {
			myTransform.position = Vector3.Lerp (myTransform.position, syncPos, Time.deltaTime * LerpRate);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
