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

    private void GetCoordinates()
    {
        bottom = GameMain.GetInstance().GetBottomBorder();
        top = GameMain.GetInstance().GetTopBorder();
        left = GameMain.GetInstance().GetLeftBorder();
        right = GameMain.GetInstance().GetRightBorder();
    }

	public Vector2 Checkout(Vector2 point, Vector2 spriteSize){
	    GetCoordinates();
	    float offcetX = spriteSize.x / 2;
	    float offcetY = spriteSize.y / 2;

        if (point.x > right + offcetX) {
			temp = point;
			temp.x = left - offcetX;
			point = temp;
		} else if (point.x < left - offcetX) {
			temp = point;
			temp.x = right + offcetX;
			point = temp;
		}

		if (point.y > top + offcetY) {
			temp = point;
			temp.y = bottom - offcetY;
			point = temp;
		} else if (point.y < bottom - offcetY) {
			temp = point;
			temp.y = top + offcetY;
			point = temp;
		}
		return point;
	}

	private static class SingletonHolder{
		public static ViciousWorldForChilds INSTANCE = new ViciousWorldForChilds ();
	}
}
