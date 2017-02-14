using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetControlScheme {

	//static int count = 0;

	public static int getControls(float pos){
		if (pos <= 0) {
			//count++;
			return 0;
		} else {
			return 1;
		}
	}
}
