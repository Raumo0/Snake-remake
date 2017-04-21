using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
	public Text countText; 
	public Text winText;

    private Rigidbody2D rb2d;
	private int count;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		winText.text = "";
		SetCountText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
	    float moveHorizontal = Input.GetAxis("Horizontal");
	    float moveVertical = Input.GetAxis("Vertical");
	    Vector2 movement = new Vector2(moveHorizontal, moveVertical);
//	    rb2d.AddForce(movement * speed);
//		rb2d.position.X += moveHorizontal * speed;
//		rb2d.position.Y += moveVertical * speed;
		rb2d.position += movement * speed;
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) {
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("Bird")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 2)
			//... then set the text property of our winText object to "You win!"
			winText.text = "You win!";
	}
}
