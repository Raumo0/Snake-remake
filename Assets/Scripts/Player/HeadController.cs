using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadController : PartController {
	protected override void FixedUpdate() {
		base.FixedUpdate ();
    }

//	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
//	void OnTriggerEnter2D(Collider2D other) {
//		if (other.gameObject.CompareTag("Bird")) {
//			other.gameObject.SetActive(false);
//			count = count + 1;
//			SetCountText();
//		}
//	}

	public Vector2 TurnRight(float angle, Vector2 direction, float turnAcceleration, float speed){
		float route = angle;
		direction = turn(direction, route);
		roundAngle(route);
		values.position = Move(values.position, direction, speed, turnAcceleration);
		return direction;
	}

	public Vector2 TurnLeft(float angle, Vector2 direction, float turnAcceleration, float speed){
		float route = -angle;
		direction = turn(direction, route);
		roundAngle(route);
		values.position = Move(values.position, direction, speed, turnAcceleration);
		return direction;
	}

	private Vector2 turn(Vector2 vector, float route){
		float rad = route * Mathf.Deg2Rad;
		float x = (float)(vector.x * Mathf.Cos(rad) - vector.y * Mathf.Sin(rad));
		float y = (float)(vector.x * Mathf.Sin(rad) + vector.y * Mathf.Cos(rad));
		return new Vector2(x, y);
	}

	public Vector2 Move(Vector2 point, Vector2 direction, float speed, float acceleration){
		point.x += direction.x * speed * acceleration;
		point.y += direction.y * speed * acceleration;
		return point;
	}

	private void roundAngle(float route){
		values.rotation += route;
		if (values.rotation >= 360 || values.rotation <= -360)
			values.rotation %= 360;
	}
}
