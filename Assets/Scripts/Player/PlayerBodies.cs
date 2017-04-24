using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodies : MonoBehaviour {
	public int distance;

	void Awake() {
		if (distance == 0)
			distance = 5;
	}
}
