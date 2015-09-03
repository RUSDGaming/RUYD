using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public LobbyManager lobbyManager;



	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	public void OnClickHost ()
	{
		lobbyManager.StartHost ();
		lobbyManager.showLobbyGUI = true;
		lobbyManager.ChangeTo (lobbyManager.hostPannel);
	}
	
	public void OnClickJoin ()
	{
		//lobbyManager.ChangeTo (lobbyPanel);
		
		//lobbyManager.networkAddress = ipInput.text;
		lobbyManager.networkAddress = "localhost";
		lobbyManager.StartClient ();
		lobbyManager.showLobbyGUI = true;
		lobbyManager.ChangeTo (lobbyManager.joinPannel);
		
		//lobbyManager.backDelegate = lobbyManager.StopClientClbk;
		//	lobbyManager.DisplayIsConnecting ();
		
		//lobbyManager.SetServerInfo ("Connecting...", lobbyManager.networkAddress);
	}

}
