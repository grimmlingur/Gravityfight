using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCollect : MonoBehaviour {

    public float distbehind;

    void Start()
    {
        Debug.Log("Asteroid exists");
    }
	void OnTriggerEnter(Collider other){
        Debug.Log("Colliding with: "+ other.tag);
		if (other.gameObject.CompareTag("Boundary")) {
			return;
		}
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player collision handling");
            //move behind
            Transform thistransform=GetComponent<Transform>();
            Transform othertransform=other.gameObject.GetComponent<Transform>();
            thistransform.position=othertransform.position - distbehind*othertransform.forward;
            other.gameObject.GetComponent<player>().attach(gameObject,distbehind);
        }
	}
}
