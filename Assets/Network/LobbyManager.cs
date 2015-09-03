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
