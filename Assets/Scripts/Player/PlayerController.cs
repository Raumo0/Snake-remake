using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed;
	[SerializeField]
	private float angle;
	[SerializeField]
	private bool move;
	[SerializeField]
	private bool turnLeft;
	[SerializeField]
	private bool turnRight;
	[SerializeField]
	private bool dive;
	[SerializeField]
	private Text countText; 
	[SerializeField]
	private Text winText;

	private int count;
    private Rigidbody2D rb2d;
	private Vector2 direction;
	private float turnAcceleration;
	private bool turnLeftFlag;
	private bool turnRightFlag;

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		winText.text = "";
		SetCountText();
		move = true;
		turnLeftFlag = false;
		turnRightFlag = false;
		direction = new Vector2 (1, 0);
		turnAcceleration = .2f;
		angle = -4.5f;
	}

	void Update () {
		if (move) {
			rb2d.position += Move (1);
		}
	}

	void FixedUpdate() {
		if (!turnRight)
			turnRightFlag = false;
		else
			turnRightFlag = true;
		if (!turnLeft)
			turnLeftFlag = false;
		else
			turnLeftFlag = true;
		
		handleInput ();
		if (turnLeftFlag) {
			TurnLeft();
		}
		if (turnRightFlag) {
			TurnRight();
		}
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Bird")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	private void handleInput() {
		HandleInputTouch ();
		HandleInputPC ();
	}

	private void HandleInputPC() {
		if (Input.GetKey(KeyCode.RightArrow)) {
			turnRightFlag = true;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			turnLeftFlag = true;
		}
	}

	private void HandleInputTouch() {
		if (Input.touchCount > 0) {
			if (Input.GetTouch(0).position.x > GameMain.GetInstance().GetWidth() / 2)
				turnRightFlag = true;
			else
				turnLeftFlag = true;
		}
	}

	private void TurnRight(){
		float route = angle;
		direction = turn(direction, route);
		roundAngle(route);
		rb2d.position += Move(turnAcceleration);
	}

	private void TurnLeft(){
		float route = -angle;
		direction = turn(direction, route);
		roundAngle(route);
		rb2d.position += Move(turnAcceleration);
	}

	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 2)
			winText.text = "You win!";
	}

	private Vector2 Move(float acceleration){
		return new Vector2(direction.x * speed * acceleration,
			direction.y * speed * acceleration);
	}

	private Vector2 turn(Vector2 vector, float route){
		float rad = route * Mathf.Deg2Rad;
		float x = (float)(vector.x * Mathf.Cos(rad) - vector.y * Mathf.Sin(rad));
		float y = (float)(vector.x * Mathf.Sin(rad) + vector.y * Mathf.Cos(rad));
		return new Vector2(x, y);
	}

	private void roundAngle(float route){
		rb2d.rotation += route;
		if (rb2d.rotation >= 360 || rb2d.rotation <= -360)
			rb2d.rotation %= 360;
	}

	public void diveChange(){
		dive = !dive;
	}
}
