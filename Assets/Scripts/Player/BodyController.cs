using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : PartController {
	private LinkedList<Entity> parts;
    public int distance;

	protected override void Awake() {
		base.Awake ();
		parts = new LinkedList<Entity> ();
	    if (distance == 0)
            distance = 5;
	}

	protected override void FixedUpdate () {
		base.FixedUpdate ();
		if (distance != parts.Count) {
			if (distance > parts.Count) {
				for (int i = parts.Count; i < distance; i++) {
					parts.AddLast(values.GetClone (new Entity (new Vector2 (), 0, new Vector2(), false)));
				}
			} else if (distance < parts.Count) {
				for (int i = distance; i < parts.Count; i++) {
					parts.RemoveLast();
				}
			}
		}
	}

	public override Entity Advance(Entity entity){
		if (entity == null || entity.position == null || parts == null)
			return entity;
		
		Entity lastElement = values;
		if (parts.Count == 0) {
			values = entity;
			return lastElement;
		}
		values = GameMain.GetInstance().GetByIndex(parts, parts.Count-1);
		int len = parts.Count - 1;
		Entity before;
		Entity part;
		for (int i = len; i > 0; i--){
			before = GameMain.GetInstance().GetByIndex(parts, i - 1);
			part = GameMain.GetInstance().GetByIndex(parts, i);
			if (part.position.Equals(before.position))
				continue;
			part.position.x = before.position.x;
			part.position.y = before.position.y;
			part.rotation = before.rotation;
		    part.dive = before.dive;
		    part.scale = before.scale;
		}
		Entity first = parts.First.Value;
		first.position.x = entity.position.x;
		first.position.y = entity.position.y;
		first.rotation = entity.rotation;
	    first.dive = entity.dive;
	    first.scale = entity.scale;
		return lastElement;
	}
}
