using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryMove : MonoBehaviour {
	private float xBoundary;
	private float yBoundary;

	private float offsetX;
	private float offsetY;

	void Start(){
		xBoundary = transform.localScale.x / 2;
		yBoundary = transform.localScale.y / 2;

		offsetX = xBoundary - 1;
		offsetY = yBoundary - 1;
	}

	void FixedUpdate(){
		xBoundary = transform.localScale.x / 2;
		yBoundary = transform.localScale.y / 2;

		offsetX = xBoundary - 1;
		offsetY = yBoundary - 1;
	}

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
