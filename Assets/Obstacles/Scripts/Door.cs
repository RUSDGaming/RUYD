using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour
{

	public Text countDownClock;

	bool levelOver = false;
	float remainingTime = 5;
	LobbyManager lobbymanager;

	// Use this for initialization
	void Start ()
	{
		lobbymanager = FindObjectOfType (typeof(LobbyManager)) as LobbyManager;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (levelOver) {
			remainingTime -= Time.deltaTime;

			countDownClock.text = "Time Remaing: " + remainingTime.ToString ("0.00");
		}
		if (remainingTime < 0) {
			//Application.LoadLevel ("LevelSelect");
			lobbymanager.ServerChangeScene ("LevelSelect");
		}
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			Debug.Log ("You have completed the level!!");
			// play victory message or something. 
			// go back to level select screen once all players have crossed the line or countdown has expired.

			levelOver = true;
			countDownClock.gameObject.SetActive (true);
		}
	}


}
