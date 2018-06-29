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
    private BodyController tail;
	private Transform bodies;
	private Entity entity;
    private Vector2 spriteSize;

    protected void  Start() {
		//trash-begin
//		count = 0;
//		winText.text = "";
//		SetCountText();
		//trash-end
		turnLeftFlag = false;
		turnRightFlag = false;
		direction = new Vector2 (1, 0);
		entity = new Entity (new Vector2(), 0f, new Vector2(), false);
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
			if (this.transform.GetChild(i).gameObject.CompareTag("PlayerHead"))
            {
				head = (HeadController)this.transform.GetChild(i).gameObject.GetComponent<HeadController>();
                spriteSize = (Vector2)this.transform.GetChild(i).gameObject.GetComponent<HeadController>().GetComponent<SpriteRenderer>().sprite.rect.size;
                spriteSize /= this.transform.GetChild(i).gameObject.GetComponent<HeadController>().GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            } else if (this.transform.GetChild(i).gameObject.CompareTag ("PlayerBody"))
            {
				bodies = this.gameObject.transform.GetChild (i);
			} else if (this.transform.GetChild(i).gameObject.CompareTag("PlayerTail"))
			{
			    tail = this.gameObject.transform.GetChild(i).gameObject.GetComponent<BodyController>();
			}
		}
	}

	void FixedUpdate (){
		if (move) {
		    entity = head.FillValues(entity);
			entity.position = head.Move (
				entity.position, 
				direction, speed, 
				turnAcceleration
			);
		}
		var variable = this.AdvanceBodies (head.values);
	    this.AdvanceTail(variable);
		entity = head.Advance (entity);

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

    private Entity AdvanceTail(Entity entity)
    {
        entity = tail.Advance(entity);
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
        if (Input.GetKeyDown(KeyCode.Space))
	    {
	        head.values.dive = !head.values.dive;
	    }
	}

	private void HandleInputTouch() {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            if (p.x > GameMain.GetInstance().GetWidth() / 2)
                turnRightFlag = true;
            else turnLeftFlag = true;
        }
    }
		
	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
//	void SetCountText() {
//		countText.text = "Count: " + count.ToString();
//		if (count >= 2)
//			winText.text = "You win!";
//	}
}
