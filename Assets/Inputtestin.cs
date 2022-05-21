using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputtestin : MonoBehaviour
{
    // Start is called before the first frame update

    float moveX;
    float moveY;

    private void Update()
    {
        if (moveX > 0)
        {
            Debug.Log("Pressing D!");
        }
        if (moveX < 0)
        {
            Debug.Log("Pressing A!");
        }

        if (moveY > 0)
        {
            Debug.Log("Pressing W!");
        }
        if (moveY < 0)
        {
            Debug.Log("Pressing S!");
        }
    }

    void OnHorizontalMove(InputValue val) 
    {
        moveX = val.Get<float>();
    }

    void OnVerticalMove(InputValue val)
    {
        moveY = val.Get<float>();
    }
}
