﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryShrink : MonoBehaviour {

	private float minMark;
	private float interval;
	private float stop;

	public GameObject topWall;
	public GameObject bottomWall;
	public GameObject rightWall;
	public GameObject leftWall;

	// Use this for initialization
	void Start () {
		minMark = 60;
		interval = 0.5f;
		stop = 90;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time > minMark) && (Time.time < stop)) {
			minMark = Time.time + interval;
			transform.localScale -= new Vector3 (0.3f, 0.3f, 0);
			topWall.transform.localScale += new Vector3 (0.0f, 0.3f, 0);
			bottomWall.transform.localScale += new Vector3 (0.0f, 0.3f, 0);
			rightWall.transform.localScale += new Vector3 (0.3f, 0, 0);
			leftWall.transform.localScale += new Vector3 (0.3f, 0, 0);
		}
	}
}
