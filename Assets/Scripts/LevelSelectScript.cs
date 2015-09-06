using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LevelSelectScript : NetworkBehaviour
{

	LobbyManager lobbyManager;

	// Use this for initialization
	void Start ()
	{
		lobbyManager = FindObjectOfType (typeof(LobbyManager)) as LobbyManager;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void LoadScene (string scene)
	{
		if (isServer) {

			lobbyManager.ServerChangeScene (scene);
			//LoadLevel (scene);
			return;
		}
		if (isClient) {
			//	RpcLoadLevel (scene);
		}
	}

	[ClientRpc]
	void RpcLoadLevel (string scene)
	{
		LoadLevel (scene);
	}
	void LoadLevel (string scene)
	{

		Application.LoadLevel (scene);
	}



}
