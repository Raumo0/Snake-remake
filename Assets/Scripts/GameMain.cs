using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain {
	Camera  camera = Camera.main;

	private GameMain(){
	}

	public static GameMain GetInstance(){
		return SingletonHolder.INSTANCE;
	}

	public Vector2 GetBottomLeft(){
		return camera.ScreenToWorldPoint(
			new Vector2 (0, 0)
		);
	}

	public Vector2 GetBottomRight(){
		return camera.ScreenToWorldPoint(
			new Vector2 (camera.pixelWidth, 0)
		);
	}

	public Vector2 GetTopLeft(){
		return camera.ScreenToWorldPoint(
			new Vector2 (0, camera.pixelHeight)
		);
	}

	public Vector2 GetTopRight(){
		return camera.ScreenToWorldPoint(
			new Vector2 (camera.pixelWidth, camera.pixelHeight)
		);
	}

	public float GetWidth(){
		return this.GetTopRight().x - this.GetTopLeft().x;
	}

	public float GetHeight(){
		return this.GetTopRight().y - this.GetBottomRight().y;
	}

	public Vector2 GetSize(){
		Vector2 result = new Vector2(GetWidth(), 
			GetHeight()
		);
		return result;
	}

	public float GetLeftBorder(){
		return GetBottomLeft ().x;
	}

	public float GetRightBorder(){
		return GetBottomRight ().x;
	}

	public float GetBottomBorder(){
		return GetBottomLeft ().y;
	}

	public float GetTopBorder(){
		return GetTopLeft ().y;
	}

	private static class SingletonHolder{
		public static readonly GameMain INSTANCE = new GameMain();
	}
}
