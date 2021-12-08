using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private bool _canShoot;
    private bool _facingRight;

    public GameObject bullet;
    public Transform firepoint;
    
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        moveSpeed = 5f;
        jumpForce = 2.5f;
        _canShoot = true;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space") && _canShoot)
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = new Vector2();
        position.x = moveHorizontal * moveHorizontal * moveSpeed * Time.deltaTime;
        if (moveHorizontal > 0 && _facingRight || moveHorizontal < 0 && !_facingRight)
        {
            Flip();
        }

        if (moveHorizontal != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        
        if (!isJumping && moveVertical > 0f)
        {
            rigidBody2D.AddForce(new Vector2(0, moveVertical * jumpForce), ForceMode2D.Impulse);
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
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Platform"))
        {
            isJumping = true;
        }
    }

    private void Shoot()
    {
        _canShoot = false;
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        Invoke("EnableShooting", 1);
    }

    private void EnableShooting()
    {
        _canShoot = true;
    }
    
}
