using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryMove : MonoBehaviour {
	private float xBoundary = 11;
	private float yBoundary = 5;
	void OnTriggerExit(Collider other){
		if ((other.transform.position.x < -xBoundary) || (other.transform.position.x > xBoundary)) {
			other.transform.position = new Vector3 (-other.transform.position.x, other.transform.position.y, other.transform.position.z); 
		} else if ((other.transform.position.y < -yBoundary) || (other.transform.position.y > yBoundary)) {
			other.transform.position = new Vector3 (other.transform.position.x, -other.transform.position.y, other.transform.position.z); 

		}
	}
}
