using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	int player1Lives = 3;
	int player2Lives = 3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void takeDamage(string tag){
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
			} else {
				player1.GetComponentInChildren<player> ().respawn ();

			}
		} else {
			if (player2Lives == 0) {
				Debug.Log ("Player 2 loses!!!!");
			} else {
				player2.GetComponentInChildren<player> ().respawn ();
			}
		}
	}
}
