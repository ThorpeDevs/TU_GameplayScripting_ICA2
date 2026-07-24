using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed; // Private As No Intention to Add Sprint Or Anything
    [SerializeField] private SpriteRenderer sprRenderer;
    [SerializeField] private Animator animator;
    
    private float speedX, speedY;
    private Rigidbody2D rb;
    
    void Start() {rb = GetComponent<Rigidbody2D>();} // Gets Rigidbody On Start

    private void FixedUpdate() // Clamps To DeltaTime (so no Frame based Speed)
    {
        // Get Both Input Axis (old system)
        speedX = Input.GetAxis("Horizontal") * speed;
        speedY = Input.GetAxis("Vertical") * speed;
        // Apply To Character
        rb.linearVelocity = new Vector2(speedX, speedY);
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        
        if (speedX>0)
        {
            sprRenderer.flipX = false;
        }
        else if (speedX < 0)
        {
            sprRenderer.flipX = true;
        }
    }
}
