using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity {
	public Vector2 position;
	public float rotation;
	public float scale;
	public bool dive;

	public Entity(Vector2 position, float rotation, float scale, bool dive){
		this.position = position;
		this.rotation = rotation;
		this.scale = scale;
		this.dive = dive;
	}
}
