using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyController : MonoBehaviour {
	private LinkedList<Entity> parts;
	private PlayerBodies parentPB;
	private Rigidbody2D rb2d;

	void Start () {
		Entity entity;
		parentPB = this.transform.parent.GetComponent<PlayerBodies>();
		rb2d = this.GetComponent<Rigidbody2D> ();
		parts = new LinkedList<Entity> ();
		entity = new Entity (rb2d.position, rb2d.rotation, 0, false);
		parts.AddLast (entity);
	}

	void Update () {
		Entity entity = GameMain.GetInstance ().GetByIndex (parts, parts.Count - 1);
		rb2d.position = entity.position;
		rb2d.rotation = entity.rotation;
	}

	public LinkedList<Entity> GetParts(){
		Entity entity;
		if (parts == null || parts.Count == 0)
			return null;
		if (parentPB.distance > parts.Count - 1) {
			for (int i = parts.Count - 1; i < parentPB.distance; i++) {
				entity = new Entity (rb2d.position, rb2d.rotation, 0, false);
				parts.AddFirst (entity);
			}
		}
		if (parentPB.distance < parts.Count - 1) {
			for (int i = parts.Count - 1; i > parentPB.distance; i--) {
				parts.RemoveFirst();
			}
		}
		return parts;
	}
}
