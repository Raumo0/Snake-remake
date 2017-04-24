using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	void Update () {
		Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
		Vector2 local_sprite_size = sprite_size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
		Vector2 scale = new Vector2 (
			GameMain.GetInstance().GetSize().x / local_sprite_size.x,
			GameMain.GetInstance().GetSize().y / local_sprite_size.y
		);
		transform.localScale = scale;
	}
}
