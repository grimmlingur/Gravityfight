using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public AudioClip[] ambient;

	int player1Lives = 3;
	int player2Lives = 3;
	bool gameStarted = false;
	bool gameEnded 	 = false;
	float audioTime  = 4;
	float audioTimer = 7;
	float time = 120;

	GameObject[] UIObjects;
	GameObject[] EndUIObjects;
	GameObject[] MenuObjects;
	AudioSource source;

	void Awake(){
		Time.timeScale = 0;	
	}

	// Use this for initialization
	void Start () {

		UIObjects    = GameObject.FindGameObjectsWithTag("GameUI");
		EndUIObjects = GameObject.FindGameObjectsWithTag("EndUI");
		MenuObjects  = GameObject.FindGameObjectsWithTag("Menu");

		source = GetComponent<AudioSource> ();

		foreach(GameObject i in UIObjects){
			i.SetActive(false);
		}

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
		if (gameEnded) {
			if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
		if (gameStarted) {
			foreach (GameObject i in UIObjects) {
				if (i.name == "Player1Lives") {
					i.gameObject.GetComponent<Text> ().text = "Player 1 Lives: " + player1Lives;
				} else if (i.name == "Player2Lives") {
					i.gameObject.GetComponent<Text> ().text = "Player 2 Lives: " + player2Lives;
				}
			}
			if (Input.GetKeyDown(KeyCode.Escape)) { 
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
				Application.Quit ();
			}
		} else {
			if (Input.anyKey) {
				gameStarted = true;
				Time.timeScale = 1;

				foreach(GameObject i in UIObjects){
					i.SetActive(true);
				}

				foreach(GameObject i in MenuObjects){
					i.SetActive(false);
				}

			}
		}

		ambientMusic ();
		timer ();
	}

	void timer(){
		time -= Time.deltaTime;
		if (time <= 0) {
			if (player1Lives > player2Lives) {
				displayWin (1);
			} else if (player2Lives > player1Lives) {
				displayWin (2);
			} else {
				displayWin (0);
			}
		}
	}

	void ambientMusic(){
		if (gameStarted) {
			if (audioTimer >= audioTime) {
				source.PlayOneShot (ambient [Random.Range (0, 8)], 1f);
				audioTimer = 0;
			}
			audioTimer += Time.deltaTime;
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
				} else if (winner == 2) {
					i.gameObject.GetComponent<Text> ().text = "Player 2 Wins!";
				} else {
					i.gameObject.GetComponent<Text> ().text = "Draw!";
				}
			}
		}
		gameEnded = true;
		Time.timeScale = 0;
	}
}
