using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCollect : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}
		//If asteroid is uncollected

		if (gameObject.tag == "Uncollected") {
			return;
		}

		if (gameObject.tag == "Player1") {
			if (other.gameObject.tag == "Player2") {
				FindObjectOfType<GameController> ().takeDamage (other.gameObject.tag);
			}
		} else if (gameObject.tag == "Player2") {
			if (other.gameObject.tag == "Player1") {
				FindObjectOfType<GameController> ().takeDamage (other.gameObject.tag);
			}
		}
		//Should asteroids destroy each other?
		Destroy (gameObject);
	}
}
