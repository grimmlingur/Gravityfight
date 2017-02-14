﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCollect : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Boundary")) {
			return;
		}
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other);
            //other.gameObject.GetComponent<player>().attach(gameObject);
        }
	}
}
