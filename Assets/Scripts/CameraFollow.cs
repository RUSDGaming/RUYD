using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraFollow : MonoBehaviour
{

	public Transform playerTransform;
	private float maxDeltaX = 5;
	private float maxDeltaY = 5;
	// Use this for initialization
	void Start ()
	{
		findPlayer ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (playerTransform == null) {
			findPlayer ();
			if (playerTransform == null) {
				return;
			}
		}
		float deltaX = transform.position.x - playerTransform.position.x;
		float deltaY = transform.position.y - playerTransform.position.z;

		float x = transform.position.x;
		float y = transform.position.y;

		if (Mathf.Abs (deltaX) > maxDeltaX) {
			//	Debug.Log ("deltaX: " + deltaX);

			x = playerTransform.position.x + maxDeltaX * Mathf.Sign (deltaX);
			//Debug.Log (x);
		}
		
		if (Mathf.Abs (deltaY) > maxDeltaY) {
			y = playerTransform.position.y + maxDeltaY * Mathf.Sign (deltaY);
		}



		transform.position = new Vector3 (x, y, -10);
		//Debug.Log ("pos:" + transform.position);
	}

	public void findPlayer ()
	{
		//Debug.Log ("looking for player");
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject go in players) {
			//		PlayerController pc = go.GetComponent<PlayerController> ();
			DebugPlayerController dpc = go.GetComponent<DebugPlayerController> ();
			if (dpc != null) {
				playerTransform = go.transform;
				break;
			}

			if (go != null) {
				NetworkIdentity nv = go.GetComponent<NetworkIdentity> ();
				if (nv.isLocalPlayer) {
					playerTransform = go.transform;
					break;
				}
			}
		}
	}
}
