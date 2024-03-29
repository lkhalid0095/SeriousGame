using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigidBody2D;
    private float _moveSpeed;
    private float _jumpForce;
    private bool _isJumping;
    private float _moveHorizontal;
    private float _moveVertical;
    private bool _canShoot;
    private bool _facingRight;

    public GameObject bullet;
    public Transform firepoint;
    
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        _anim = gameObject.GetComponentInChildren<Animator>();
        if (SceneManager.GetActiveScene().name.Contains("BoxyKong"))
        {
            _moveSpeed = 10f;
        }
        else
        {
            _moveSpeed = 5f;
        }
        _jumpForce = 5f;
        _canShoot = true;
        _isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space") && _canShoot)
        {
            Shoot();
        }
        
        
    }

    void FixedUpdate()
    {
        Vector2 position = new Vector2();
        position.x = _moveHorizontal * _moveHorizontal * _moveSpeed * Time.deltaTime;
        if (_moveHorizontal > 0 && _facingRight || _moveHorizontal < 0 && !_facingRight)
        {
            Flip();
        }

        if (_moveHorizontal != 0)
        {
            _anim.SetBool("isRunning", true);
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }

        position.y = _moveVertical * _jumpForce * Time.deltaTime;

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
            _isJumping = false;
        } else if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            _anim.SetBool("isDie", true);
            PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") - 20);
            Invoke(nameof(RestartLevel), 0.5f);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Platform"))
        {
            _isJumping = true;
        }
    }

    private void Shoot()
    {
        _canShoot = false;
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        Invoke(nameof(EnableShooting), 1);
    }

    private void EnableShooting()
    {
        _canShoot = true;
    }

    void OnBecameInvisible()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0 && SceneManager.GetActiveScene().name.Contains("Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") - 20);
        }
    }
    
}
