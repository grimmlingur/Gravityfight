using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCollect : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}
		Destroy (gameObject);
	}
}
