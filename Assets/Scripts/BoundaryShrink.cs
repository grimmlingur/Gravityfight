using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryShrink : MonoBehaviour {

	private float minMark;
	private float interval;

	// Use this for initialization
	void Start () {
		minMark = 10;
		interval = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > minMark) {
			minMark = Time.time + interval;
			transform.localScale -= new Vector3 (0.3f, 0.3f, 0);
		}
	}
}
