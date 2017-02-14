using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCollect : MonoBehaviour {

    public float distbehind;

    void Start()
    {
    }

	void OnTriggerEnter(Collider other){
        Debug.Log("Colliding with: "+ other.tag);
		if (other.gameObject.CompareTag("Boundary")) {
			return;
		}
        if((other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")) && gameObject.CompareTag("Uncollected") )
        {
            Debug.Log("player attachment handling");
            //move behind
            Transform thistransform=GetComponent<Transform>();
            Transform othertransform=other.gameObject.GetComponent<Transform>();
            thistransform.position=othertransform.position - distbehind*othertransform.forward;
            other.gameObject.GetComponent<player>().attach(gameObject,distbehind);
        }
		//If asteroid is uncollected

		if (gameObject.tag == "Uncollected") {
			return;
		}

		if (gameObject.tag == "Player1") {
			if (other.gameObject.tag == "Player2") {
                Debug.Log("Player 2 takes damage");
				FindObjectOfType<GameController> ().takeDamage (other.gameObject.tag);
			}
		} else if (gameObject.tag == "Player2") {
			if (other.gameObject.tag == "Player1") {
                Debug.Log("Player 1 takes damage");
				FindObjectOfType<GameController> ().takeDamage (other.gameObject.tag);
			}
		}
		//Should asteroids destroy each other?
		//Destroy (gameObject);
	}
}
