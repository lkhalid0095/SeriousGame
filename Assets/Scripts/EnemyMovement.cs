using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    private Rigidbody2D _rigidBody2D;
    private float _moveSpeed;
    //private float _jumpForce;
    //private bool _isJumping;
    private float _moveHorizontal;
    //private float _moveVertical;
    private bool _facingRight;

    private Animator anim;
    
    public GameObject bullet;
    public Transform firepoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        _moveSpeed = 5f;
        _moveHorizontal = 1;
        anim = gameObject.GetComponentInChildren<Animator>();
        InvokeRepeating(nameof(Shoot), 1, 2f);
    }
    
    private void FixedUpdate()
    {
        Vector2 position = new Vector2();
        position.x = _moveHorizontal * _moveHorizontal * _moveSpeed * Time.deltaTime;
        if (_moveHorizontal > 0 && _facingRight || _moveHorizontal < 0 && !_facingRight)
        {
            Flip();
        }
        
        anim.SetBool("isRunning", true);
        
        transform.Translate(position);
    }

    private void Flip()
    {
        transform.Rotate(0, 180f, 0);
        _facingRight = !_facingRight;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform") || other.CompareTag("InvisibleWall"))
        {
            _moveHorizontal *= -1;
        } else if (other.CompareTag("Bullet"))
        {
            _moveHorizontal = 0;
            CancelInvoke(nameof(Shoot));
            anim.SetBool("isDie", true);
            Destroy(other.gameObject);
            Invoke(nameof(KillEnemy), 0.5f);
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
    
    private void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
    
}
