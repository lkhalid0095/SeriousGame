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
    private bool _facingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        moveHorizontal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        Vector2 position = new Vector2();
        position.x = moveHorizontal * moveHorizontal * moveSpeed * Time.deltaTime;
        if (moveHorizontal > 0 && _facingRight || moveHorizontal < 0 && !_facingRight)
        {
            Flip();
        }
        
        transform.Translate(position);
    }

    void Flip()
    {
        transform.Rotate(0, 180f, 0);
        _facingRight = !_facingRight;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            moveHorizontal *= -1;
        } else if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
