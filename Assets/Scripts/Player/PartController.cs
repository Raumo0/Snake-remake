using System.Collections;
using System.Collections.Generic;
using Snake.GenericScripts.Constants;
using UnityEngine;

public abstract class PartController : MonoBehaviour, Advance {
	[HideInInspector]
	public Entity values;
	public Rigidbody2D rb2d;
    private SpriteRenderer renderer;

    protected virtual void Awake () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		values = new Entity (rb2d.position, rb2d.rotation, 0f, false);
        renderer = this.GetComponent<SpriteRenderer>();
    }

	protected virtual void FixedUpdate () {
		rb2d.position = values.position;
		rb2d.rotation = values.rotation;
	    renderer.sortingLayerName = values.dive ? 
            ProjectConstants.SORTING_LAYER_DIVE_DOWN : 
            ProjectConstants.SORTING_LAYER_DIVE_UP;
	}

	public virtual Entity Advance(Entity entity){
		Entity lastValue = values;
		values = entity;
		return lastValue;
	}
}
