using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViciousWorldForChilds : MonoBehaviour {
	private Rigidbody2D rb2d;
	private Vector3 temp;
	private float bottom;
	private float top;
	private float left;
	private float right;

	void Update () {
		bottom = GameMain.GetInstance().GetBottomBorder();
		top = GameMain.GetInstance().GetTopBorder();
		left = GameMain.GetInstance().GetLeftBorder();
		right = GameMain.GetInstance().GetRightBorder();

		for (int i = 0; i < this.gameObject.transform.childCount; i++) {
			if (!this.gameObject.transform.GetChild (i).gameObject.activeSelf)
				continue;
			rb2d = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
			if (rb2d.position.x > right) {
				temp = rb2d.position;
				temp.x = left;
				rb2d.position = temp;
			} else if (rb2d.position.x < left) {
				temp = rb2d.position;
				temp.x = right;
				rb2d.position = temp;
			}

			if (rb2d.position.y > top) {
				temp = rb2d.position;
				temp.y = bottom;
				rb2d.position = temp;
			} else if (rb2d.position.y < bottom) {
				temp = rb2d.position;
				temp.y = top;
				rb2d.position = temp;
			}
		}
	}
}
