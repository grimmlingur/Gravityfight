using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	Vector3 originPoint;
	float speed             = 5f;
	float rotateSpeed       = 3f;
	float invincibilityTime = 2f;
	float respawnTime       = 1f;
	int controls;


	// Use this for initialization
	void Start () {
		//Gets the controlScheme for the player. GetControlScheme returns either 0 or 1 based on where the 
		//player is in the gameworld. If 0 then the player uses asd to control and if 1 then he uses jkl.
		controls = GetControlScheme.getControls (gameObject.transform.position.x);
		originPoint = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
		//Debug.Log (gameObject.transform.position);
		if (controls == 0) {
			if (Input.GetKey (KeyCode.A)) {
				gameObject.transform.Rotate (new Vector3 (0, -rotateSpeed, 0));
			}
			if (Input.GetKey (KeyCode.D)) {
				gameObject.transform.Rotate (new Vector3 (0, rotateSpeed, 0));
			}
		} else {
			if (Input.GetKey (KeyCode.J)) {
				gameObject.transform.Rotate (new Vector3 (0, -rotateSpeed, 0));
			}
			if (Input.GetKey (KeyCode.L)) {
				gameObject.transform.Rotate (new Vector3 (0, rotateSpeed, 0));
			}
		}
	}

	public void respawn(){
		StartCoroutine(respawnCoroutine());
	}

	IEnumerator respawnCoroutine()
	{
		yield return new WaitForSeconds(respawnTime);
		gameObject.transform.position = originPoint;
	}
}
