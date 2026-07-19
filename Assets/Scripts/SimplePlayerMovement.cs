using System;
using Unity.XR.Oculus.Input;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float speedX, speedY;
    private Rigidbody2D rb;
    
    void Start() {rb = GetComponent<Rigidbody2D>();}

    private void FixedUpdate()
    {
        speedX = Input.GetAxis("Horizontal") * speed;
        speedY = Input.GetAxis("Vertical") * speed;
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
