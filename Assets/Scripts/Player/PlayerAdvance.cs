using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvance : MonoBehaviour {
	void Update () {
		LinkedList<Entity> children = new LinkedList<Entity> ();
		Entity head = GetHead();
		LinkedList<Entity> bodies = GetBodies ();
		if (head != null)
			children.AddLast(head);
		foreach (var body in bodies) {
			children.AddLast(body);
		}
		Advance(children);
	}

	private void Advance(LinkedList<Entity> children) {
		if (children == null || children.Count <= 1)
			return;
		int len = children.Count - 1;
		Entity before;
		Entity part;
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

	private LinkedList<Entity> GetBodies() {
		LinkedList<Entity> parts = new LinkedList<Entity> ();
		LinkedList<Entity> bodies = new LinkedList<Entity> ();
		for (int i = 0; i < this.gameObject.transform.childCount; i++) {
			if (this.gameObject.transform.GetChild (i).gameObject.CompareTag ("PlayerBody")) {
				for (int j = 0; j < this.gameObject.transform.GetChild (i).childCount; j++) {
					parts = this.gameObject.transform.GetChild(i).GetChild(j).
						gameObject.GetComponent<PlayerBodyController>().GetParts();
					if (parts == null)
						continue;
					foreach (var item in parts)
						bodies.AddLast(item);
				} 

			}
		}
		return bodies;
	}

	private Entity GetHead(){
		Entity entity;
		Rigidbody2D rigidbody;
		for (int i = 0; i < this.gameObject.transform.childCount; i++) {
			if (this.gameObject.transform.GetChild (i).gameObject.CompareTag ("PlayerHead")) {
				rigidbody = this.gameObject.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ();
				//fix it. obj can't use rigidbody. Only entity
				entity = new Entity (rigidbody.position, rigidbody.rotation, 0, false);
				return entity;
			}
		}
		return null;
	}
}
