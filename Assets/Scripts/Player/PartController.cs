using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartController : MonoBehaviour, Advance {
	[HideInInspector]
	public Entity values;
	public Rigidbody2D rb2d;

	public virtual void Awake () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		values = new Entity (rb2d.position, rb2d.rotation, 0f, false);
	}

	protected virtual void FixedUpdate () {
		rb2d.position = values.position;
		rb2d.rotation = values.rotation;
	}

	public virtual Entity Advance(Entity entity){
		Entity lastValue = values;
		values = entity;
		return lastValue;
	}
}
