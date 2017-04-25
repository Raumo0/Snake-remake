using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViciousWorldForChilds {
	private Vector3 temp;
	private float bottom;
	private float top;
	private float left;
	private float right;

	private ViciousWorldForChilds(){}

	public static ViciousWorldForChilds GetInstance(){
		return SingletonHolder.INSTANCE;
	}

	public Vector2 Checkout(Vector2 point){
		bottom = GameMain.GetInstance().GetBottomBorder();
		top = GameMain.GetInstance().GetTopBorder();
		left = GameMain.GetInstance().GetLeftBorder();
		right = GameMain.GetInstance().GetRightBorder();

		if (point.x > right) {
			temp = point;
			temp.x = left;
			point = temp;
		} else if (point.x < left) {
			temp = point;
			temp.x = right;
			point = temp;
		}

		if (point.y > top) {
			temp = point;
			temp.y = bottom;
			point = temp;
		} else if (point.y < bottom) {
			temp = point;
			temp.y = top;
			point = temp;
		}
		return point;
	}

	private static class SingletonHolder{
		public static ViciousWorldForChilds INSTANCE = new ViciousWorldForChilds ();
	}
}
