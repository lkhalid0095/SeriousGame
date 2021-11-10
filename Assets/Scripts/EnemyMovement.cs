using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    private Rigidbody2D rigidBody2D;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 0.5f;
        moveHorizontal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        if (moveHorizontal > 0f || moveHorizontal < 0f)
        {
            Vector2 scale = transform.localScale;
            scale.x = moveHorizontal > 0f ? 4 : -4;
            transform.localScale = scale;
            rigidBody2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0), ForceMode2D.Impulse);
        }
        if (!isJumping && moveVertical > 0f)
        {
            rigidBody2D.AddForce(new Vector2(0, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            moveHorizontal *= -1;
        }
    }
}
