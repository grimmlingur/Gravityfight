using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	int player1Lives = 3;
	int player2Lives = 3;

	GameObject[] UIObjects;
	GameObject[] EndUIObjects;

	// Use this for initialization
	void Start () {
		UIObjects   = GameObject.FindGameObjectsWithTag("UI");
		EndUIObjects    = GameObject.FindGameObjectsWithTag("EndUI");

		foreach(GameObject i in EndUIObjects){
			i.SetActive(false);
		}
		foreach(GameObject i in UIObjects){
			if (i.name == "Player1Lives") {
				i.gameObject.GetComponent<Text> ().text = "Player 1 Lives: " + player1Lives;
			}else if (i.name == "Player2Lives") {
				i.gameObject.GetComponent<Text> ().text = "Player 2 Lives: " + player2Lives;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject i in UIObjects){
			if (i.name == "Player1Lives") {
				i.gameObject.GetComponent<Text> ().text = "Player 1 Lives: " + player1Lives;
			}else if (i.name == "Player2Lives") {
				i.gameObject.GetComponent<Text> ().text = "Player 2 Lives: " + player2Lives;
			}
		}
	}

	public void takeDamage(string tag){
		if (tag == "Player1") {
			player1Lives--;
			livesCheck (tag);
		} else {
			player2Lives--;
			livesCheck (tag);
		}
	}	

	void livesCheck(string tag){
		if (tag == "Player1") {
			if (player1Lives == 0) {
				Debug.Log ("Player 1 loses!!!!");
				displayWin (2);
			} else {
				player1.GetComponentInChildren<player> ().respawn ();

			}
		} else {
			if (player2Lives == 0) {
				Debug.Log ("Player 2 loses!!!!");
				displayWin (1);
			} else {
				player2.GetComponentInChildren<player> ().respawn ();
			}
		}
	}

	void displayWin(int winner){
		foreach(GameObject i in EndUIObjects){
			i.SetActive(true);
			if (i.name == "WinText") {
				if (winner == 1) {
					i.gameObject.GetComponent<Text> ().text = "Player 1 Wins!";
				} else {
					i.gameObject.GetComponent<Text> ().text = "Player 2 Wins!";
				}
			}
		}
	}
}
