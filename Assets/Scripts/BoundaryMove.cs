using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryMove : MonoBehaviour {
	private float xBoundary = 35;
	private float yBoundary = 20;

	private float offsetX = 34;
	private float offsetY = 19;

	void OnTriggerExit(Collider other){
		if ((other.transform.position.x < -xBoundary) || (other.transform.position.x > xBoundary)) {
			if ((other.transform.position.y < -offsetY) || (other.transform.position.y > offsetY)) {
				other.transform.position = new Vector3 (-other.transform.position.x, -other.transform.position.y, other.transform.position.z); 
			} else {
				other.transform.position = new Vector3 (-other.transform.position.x, other.transform.position.y, other.transform.position.z); 
			}
		} else if ((other.transform.position.y < -yBoundary) || (other.transform.position.y > yBoundary)) {
			if ((other.transform.position.x < -offsetX) || (other.transform.position.x > offsetX)) {
				other.transform.position = new Vector3 (-other.transform.position.x, -other.transform.position.y, other.transform.position.z);
			} else {
				other.transform.position = new Vector3 (other.transform.position.x, -other.transform.position.y, other.transform.position.z); 
			}
		}
	}
}
