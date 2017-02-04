using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

	public float pullRadius;
	public float gravitationalPull;
	public float minRadius;
	public float distanceMultiplier;

	public LayerMask layersToPull;
	
	void FixedUpdate () {
		Collider[] colliders = Physics.OverlapSphere (transform.position, pullRadius, layersToPull);
		foreach (var collider in colliders) {
			Rigidbody rb = collider.GetComponent<Rigidbody> ();
			if (rb == null)
				continue;
			
			Vector3 direction = transform.position - collider.transform.position;
			if (direction.magnitude < minRadius) 
				continue;
			
			float distance = direction.sqrMagnitude * distanceMultiplier + 1;

			rb.AddForce (direction.normalized * (gravitationalPull / distance) * rb.mass * Time.fixedDeltaTime);
		}
	}

	void OnTriggerEnter(Collider other){
		//call function in game controller with tag of player that hit the planet
	}
}
