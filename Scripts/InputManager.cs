using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTools2D {
    public enum Direction { UP, DOWN, LEFT, RIGHT, NONE };
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance;
        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public float GetHorizontalAxis()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public float GetVerticalAxis()
        {
            return Input.GetAxisRaw("Vertical");
        }

        public bool GetActionButton()
        {
            return Input.GetButtonUp("Action");
        }

        public bool GetActionAttack()
        {
            return Input.GetButtonDown("Fire1");
        }

        public Direction GetDirection()
        {
            float horizontalAxis = GetHorizontalAxis();
            if (horizontalAxis > 0) return Direction.LEFT;
            else if (horizontalAxis < 0) return Direction.RIGHT;

            float verticalAxis = GetVerticalAxis();
            if (verticalAxis > 0) return Direction.UP;
            else if (verticalAxis < 0) return Direction.DOWN;

            return Direction.NONE;
        }

        public bool GetExitMenu()
        {
            return Input.GetButtonUp("Cancel");
        }
    }
}
