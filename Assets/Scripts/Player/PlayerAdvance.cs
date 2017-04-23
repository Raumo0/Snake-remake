using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvance : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LinkedList<Rigidbody2D> children = new LinkedList<Rigidbody2D> ();
		Rigidbody2D head = GetHead();
		LinkedList<Rigidbody2D> bodies = GetBodies ();
		if (head != null)
			children.AddLast(head);
		foreach (var body in bodies) {
			children.AddLast(body);
		}
		Advance(children);
	}

	private void Advance(LinkedList<Rigidbody2D> children) {
		if (children == null || children.Count <= 1)
			return;
		int len = children.Count - 1;
		Rigidbody2D before;
		Rigidbody2D part;
		for (int i = len; i > 0; i--){
			before = GameMain.GetInstance().GetByIndex(children, i - 1);
			part = GameMain.GetInstance().GetByIndex(children, i);
			if (part.position.Equals(before.position))
				continue;
			part.position = before.position;
			part.rotation = before.rotation;
//			if (part.type == SnakePart.TextureType.tail)
//				part.scale = parts.get(0).scale;
//			else
//				part.scale = before.scale;
//			part.dive = before.dive;
		}
	}

	private LinkedList<Rigidbody2D> GetBodies() {
		LinkedList<Rigidbody2D> bodies = new LinkedList<Rigidbody2D> ();
		for (int i = 0; i < this.gameObject.transform.childCount; i++) {
			if (this.gameObject.transform.GetChild (i).gameObject.CompareTag ("PlayerBody")) {
				for (int j = 0; j < this.gameObject.transform.GetChild (i).childCount; j++) {
					bodies.AddLast(this.gameObject.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Rigidbody2D>());
				} 

			}
		}
		return bodies;
	}

	private Rigidbody2D GetHead(){
		for (int i = 0; i < this.gameObject.transform.childCount; i++) {
			if (this.gameObject.transform.GetChild (i).gameObject.CompareTag("PlayerHead"))
				return this.gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
		}
		return null;
	}

	private Rigidbody2D GetTail() {
		//todo
		return null;
	}
}
