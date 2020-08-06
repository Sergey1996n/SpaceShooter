using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    
    public void FixedUpdate()
    {
        Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        //gameObject.GetComponent<Transform>().position += direction * speed;

        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, -PlayerController.boundaryX, PlayerController.boundaryX),
            Mathf.Clamp(rb.position.y, -PlayerController.boundaryY, PlayerController.boundaryY)
            );
    }
}