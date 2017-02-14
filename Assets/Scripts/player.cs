﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	float speed = 5f;
	float rotateSpeed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed * Time.deltaTime);
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;

		if(Input.GetKey(KeyCode.A)){
			gameObject.transform.Rotate(new Vector3 (0, -rotateSpeed, 0));
		}
		if(Input.GetKey(KeyCode.D)){
			gameObject.transform.Rotate(new Vector3 (0, rotateSpeed, 0));
		}
	}

    
    /*
    public void attach(GameObject other)
    {
        Debug.Log("in attach");
        //TODO: add chain of asteroids to belong to player
        gameObject.AddComponent<SpringJoint>();
        SpringJoint joint=GetComponent<SpringJoint>();
        joint.connectedBody=other.GetComponent<Rigidbody>();
    }
    */
    
}
