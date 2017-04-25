using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : PartController {
	private LinkedList<Entity> parts;
	protected PlayerBodies parentPB;

	public override void Awake() {
		base.Awake ();
		parts = new LinkedList<Entity> ();
		parts.AddLast (values);
		parentPB = this.transform.parent.GetComponent<PlayerBodies>();
		for (int i = 0; i < 7; i++) {
			parts.AddLast (values.GetClone(new Entity(new Vector2(), 0, 0, false)));
		}
	}

	public override Entity Advance(Entity entity){
		if (entity == null || entity.position == null || parts == null || parts.Count == 0)
			return entity;
		
		Entity lastElement = values;
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
			//			if (part.type == SnakePart.TextureType.tail)
			//				part.scale = parts.get(0).scale;
			//			else
			//				part.scale = before.scale;
			//			part.dive = before.dive;
		}
		Entity first = parts.First.Value;
		first.position.x = entity.position.x;
		first.position.y = entity.position.y;
		first.rotation = entity.rotation;
		return lastElement;
	}
}
