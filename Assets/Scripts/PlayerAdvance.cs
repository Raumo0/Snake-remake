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
		Rigidbody2D child;
		for (int i = 0; i < this.gameObject.transform.childCount; i++) {
			if (!this.gameObject.transform.GetChild (i).gameObject.activeSelf)
				continue;
			child = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
			children.AddLast(child);
		}
		Advance(children);
	}

	public void Advance(LinkedList<Rigidbody2D> children) {
		int len = children.Count - 1;
		for (int i = len; i > 0; i--){
			Rigidbody2D before = GameMain.GetInstance().GetByIndex(children, i - 1);
			Rigidbody2D part = GameMain.GetInstance().GetByIndex(children, i);
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
}
