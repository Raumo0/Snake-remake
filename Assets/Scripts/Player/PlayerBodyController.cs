using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyController : MonoBehaviour {
	private LinkedList<Rigidbody2D> parts;
	private PlayerBodies parentPB;

	// Use this for initialization
	void Start () {
		parts = new LinkedList<Rigidbody2D> ();
		parts.AddLast (this.GetComponent<Rigidbody2D>());
		parentPB = this.transform.parent.GetComponent<PlayerBodies>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public LinkedList<Rigidbody2D> GetParts(){
		if (parentPB.distance > parts.Count - 1) {
			for (int i = parts.Count - 1; i < parentPB.distance; i++) {
				parts.AddFirst(Rigidbody2D.Instantiate(parts.First.Value));
			}
		}
		if (parentPB.distance < parts.Count - 1) {
			for (int i = parts.Count - 1; i > parentPB.distance; i--) {
				print ("------------------");
				print (parts.Count);
				parts.RemoveFirst();
				print (parts.Count);
				print ("------------------");
			}
		}
//		print ("distance: " + parentPB.distance);
//		print ("count: " + parts.Count);
		return parts;
	}
}
