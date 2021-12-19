using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStillShooting : MonoBehaviour
{
    
    private Rigidbody2D _rigidBody2D;
    private float _moveSpeed;
    private float _moveHorizontal;
    private bool _facingRight;

    private Animator anim;
    
    public GameObject bullet;
    public Transform firepoint;
    
    void Start()
    {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        InvokeRepeating(nameof(Shoot), 1, 2f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
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
