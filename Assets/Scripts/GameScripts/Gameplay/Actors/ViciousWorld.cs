using UnityEngine;

namespace Snake.GameScripts.Gameplay.Actors
{
    public class ViciousWorld : MonoBehaviour
    {
        public float offcetX;
        public float offcetY;

        private Vector3 temp;
        private float bottom;
        private float top;
        private float left;
        private float right;
        private Vector2 point;
        private Vector2 spriteSize;

        public void Awake()
        {
            spriteSize = GetComponent<SpriteRenderer>().sprite.rect.size / 
                GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            GetCoordinates();
            if (offcetX == 0)
                offcetX = .5f;
            if (offcetY == 0)
                offcetY = .5f;
        }

        private void GetCoordinates()
        {
            bottom = GameMain.GetInstance().GetBottomBorder();
            top = GameMain.GetInstance().GetTopBorder();
            left = GameMain.GetInstance().GetLeftBorder();
            right = GameMain.GetInstance().GetRightBorder();
        }

        public void FixedUpdate()
        {
            point = GetComponent<Rigidbody2D>().position;

            if (point.x > right + (spriteSize.x * offcetX))
            {
                temp = point;
                temp.x = left - (spriteSize.x * offcetX);
                point = temp;
            }
            else if (point.x < left - (spriteSize.x * offcetX))
            {
                temp = point;
                temp.x = right + (spriteSize.x * offcetX);
                point = temp;
            }

            if (point.y > top + (spriteSize.y * offcetY))
            {
                temp = point;
                temp.y = bottom - (spriteSize.y * offcetY);
                point = temp;
            }
            else if (point.y < bottom - (spriteSize.y * offcetY))
            {
                temp = point;
                temp.y = top + (spriteSize.y * offcetY);
                point = temp;
            }
            GetComponent<Rigidbody2D>().position = point;
        }
    }
}