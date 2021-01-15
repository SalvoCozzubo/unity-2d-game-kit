using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        return Input.GetButton("Action");
    }
}
