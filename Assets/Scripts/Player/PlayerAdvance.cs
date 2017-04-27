using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAdvance : MonoBehaviour {
		[SerializeField]
		private float speed;
		[SerializeField]
		private float angle;
		[SerializeField]
		public float turnAcceleration;
		[SerializeField]
		private bool move;
		[SerializeField]
		private bool turnLeft;
		[SerializeField]
		private bool turnRight;
//		[SerializeField]
//		private Text countText; 
//		[SerializeField]
//		private Text winText;

//		private int count;
		private Vector2 direction;
		private bool turnLeftFlag;
		private bool turnRightFlag;
	private HeadController head;
	private Transform bodies;
	private Entity qqq;

	protected void  Start() {
		//trash-begin
//		count = 0;
//		winText.text = "";
//		SetCountText();
		//trash-end
		turnLeftFlag = false;
		turnRightFlag = false;
		direction = new Vector2 (1, 0);
		qqq = new Entity (new Vector2(), 0f, 0f, false);
	}

	void Awake() {
		if (angle == 0f)
			angle = -4.5f;
		if (speed == 0f)
			speed = 0.03f;
		if (turnAcceleration == 0f)
			turnAcceleration = .1f;
		move = true;
		for (int i = 0; i < this.transform.childCount; i++) {
			if (this.transform.GetChild(i).gameObject.CompareTag("PlayerHead")) {
				head = (HeadController)this.transform.GetChild(i).gameObject.GetComponent<HeadController>();
			} else if (this.transform.GetChild(i).gameObject.CompareTag ("PlayerBody")) {
				bodies = this.gameObject.transform.GetChild (i);
			}
		}
	}

	void FixedUpdate (){
		if (move) {
			qqq = head.values.GetClone(qqq);
			qqq.position = head.Move (
				qqq.position, 
				direction, speed, 
				turnAcceleration
			);
		}
		this.AdvanceBodies (head.values);
		qqq.position = ViciousWorldForChilds.GetInstance ().Checkout(qqq.position);
		qqq = head.Advance (qqq);

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
			direction = head.TurnLeft(angle, direction, turnAcceleration, speed);
		}
		if (turnRightFlag) {
			direction = head.TurnRight(angle, direction, turnAcceleration, speed);
		}
	}
		
	private Entity AdvanceBodies(Entity entity){
		for (int i = 0; i < bodies.childCount; i++) {
			entity = bodies.GetChild(i).
				gameObject.GetComponent<BodyController> ().Advance(entity);
		}
		return entity;
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
        //if (Input.touchCount > 0) {
        //	if (Input.GetTouch(0).position.x > GameMain.GetInstance().GetWidth() / 2)
        //		turnRightFlag = true;
        //	else
        //		turnLeftFlag = true;
        //}


        if (Input.touchCount > 0)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(
            new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y));
            if (point.x > GameMain.GetInstance().GetWidth() / 2)
                turnRightFlag = true;
            else
                turnLeftFlag = true;
            if (Input.touchCount > 1)
            {
                point = Camera.main.ScreenToWorldPoint(
                new Vector2(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y));
                if (point.x > GameMain.GetInstance().GetWidth() / 2)
                    turnRightFlag = true;
                else
                    turnLeftFlag = true;
            }
        }
    }
		
	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
//	void SetCountText() {
//		countText.text = "Count: " + count.ToString();
//		if (count >= 2)
//			winText.text = "You win!";
//	}
}
