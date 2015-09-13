using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LobbyManager : NetworkLobbyManager
{

	static public LobbyManager s_Singleton;

	public GameObject mainPannel;
	public GameObject hostPannel;
	public GameObject joinPannel;

	public GameObject currentPanel;

	// Use this for initialization
	void Start ()
	{
		s_Singleton = this;
		ChangeTo (mainPannel);
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public override void OnServerSceneChanged (string sceneName)
	{
		base.OnServerSceneChanged (sceneName);
		Debug.Log ("changed");
	}
	public override void OnClientSceneChanged (NetworkConnection conn)
	{
		base.OnClientSceneChanged (conn);
		Debug.Log ("client scene changed");
		ChangeTo (null);
		NetworkCommands[] players = FindObjectsOfType<NetworkCommands> (); 
		foreach (NetworkCommands go in players) {
			if (go.isLocalPlayer) {
				go.CmdIChangedLevel ();
			}
		}


		
		// if there is a dbpc in the scene kill it with fire thankyou.
		DebugPlayerController dbpc = FindObjectOfType (typeof(DebugPlayerController)) as DebugPlayerController;
		if (dbpc != null) {
			Destroy (dbpc.gameObject);
		}
	

	}

	public void createPlayer (NetworkConnection conn)
	{
		Debug.Log ("creating a player");
		GameObject player = (GameObject)Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);
		//	player.GetComponent<Player>().color = Color.red;

		NetworkServer.AddPlayerForConnection (conn, player, (short)conn.connectionId);
	}

	
	public void ChangeTo (GameObject newPanel)
	{
		if (currentPanel != null) {
			currentPanel.gameObject.SetActive (false);
		}
		
		if (newPanel != null) {
			newPanel.gameObject.SetActive (true);
		}
		
		currentPanel = newPanel;
		

	}



}
