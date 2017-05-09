using System.Collections;
using System.Collections.Generic;
using Snake.GenericScripts.Constants;
using UnityEngine;

public abstract class PartController : MonoBehaviour, Advance {
	[HideInInspector]
	public Entity values;
	public Rigidbody2D rb2d;
    private SpriteRenderer renderer;

    protected virtual void Awake ()
    {
        bool dive;
        Vector2 scale = transform.localScale;
		rb2d = this.GetComponent<Rigidbody2D>();
        if (GetComponent<SpriteRenderer>().sortingLayerName == "Dive_down")
            dive = true;
        else dive = false;
        values = new Entity (rb2d.position, rb2d.rotation, scale, dive);
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

    public Entity FillValues(Entity entity)
    {
        if (entity == null)
            entity = new Entity(new Vector2(), 0, new Vector2(), false);
        if (entity.position == null)
            entity.position = new Vector2();
        entity.position.x = rb2d.position.x;
        entity.position.y = rb2d.position.y;
        entity.rotation = rb2d.rotation;
        entity.scale = transform.localScale;
        entity.dive = GetComponent<SpriteRenderer>().sortingLayerName == "Dive_down";
        return entity;
    }
}
