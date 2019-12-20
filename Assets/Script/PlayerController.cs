using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private Move _moveController;
    static private Vector2 spawnTrancelate;
    private Rigidbody2D _rb;
    private bool _isGround;
    private bool _canShoot = true;
    private static bool _attackDirectionFlag; // true : front, false, back
    private string _state;
    private float timeFromLastShot = 0;
    private Animator _animator;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpFlag = 1.5f;
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private float shotDelay = 0.1f;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject swapDirectionBullet;
    private bool _goalFlag;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveController = new Move(moveSpeed, jumpSpeed, _rb, maxSpeed);
        _attackDirectionFlag = true;
        _state = "Stop";
        if (spawnPoint != null) PlayerController.spawnTrancelate = spawnPoint.transform.position;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canShoot)
        {
            timeFromLastShot += Time.deltaTime;
            if (timeFromLastShot > shotDelay)
            {
                _canShoot = true;
                timeFromLastShot = 0;
            }
        }
        if (Mathf.Abs(_rb.velocity.y) > jumpFlag) _isGround = false;
        else _isGround = true;
        List<int> direction = new List<int> { };
        if (Input.GetKey(KeyCode.D)) direction.Add(0);
        if (Input.GetKey(KeyCode.A)) direction.Add(1);
        DecideState(direction);
        _moveController.move(direction);
        if (Input.GetKey(KeyCode.Space)) _moveController.Jump(_isGround);
        if (direction.IndexOf(1) != -1 && direction.IndexOf(0) == -1) _attackDirectionFlag = false;
        else if (direction.IndexOf(0) != -1 && direction.IndexOf(1) == -1) _attackDirectionFlag = true;
        if (Input.GetKey(KeyCode.J) && _canShoot) Shoot();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("DeathZone"))
        {
            Death();
        }
        else if (collider.gameObject.CompareTag("Goal"))
        {
            Goal();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(this.gameObject);
        GameObject obj = (GameObject)Resources.Load("Prefab/Player"); Instantiate(obj, spawnTrancelate, Quaternion.identity); 
    }

    void Shoot()
    {
        Vector3 shooter = gun.transform.position;
        if (_attackDirectionFlag) Instantiate(bullet, shooter, Quaternion.identity);
        else Instantiate(swapDirectionBullet, shooter, Quaternion.identity);
        _canShoot = false;
    }
    void DecideState(List<int> d)
    {
        if (_isGround)
        {
            if (d.IndexOf(0) != d.IndexOf(1) && ((d.IndexOf(0) != -1 || d.IndexOf(1) != -1)))
            {
                _animator.SetBool("Walk", true);
                print("walking");
            }
            else _animator.SetBool("Walk", false);
            _animator.SetBool("Jump", false);
            _animator.SetBool("Fall", false);
        }
        else
        {
            if (_rb.velocity.y > jumpFlag)
            {
                _animator.SetBool("Jump", true);
                _animator.SetBool("Fall", false);
            }
            else
            {
                _animator.SetBool("Fall", true);
                _animator.SetBool("Jump", false); 
            }
            _animator.SetBool("Walk", false);
        }
        _animator.SetBool("Right", _attackDirectionFlag);
        if (_attackDirectionFlag) print("right");
    }
    void Goal()
    {
        if (_goalFlag) return;
        GameObject obj = (GameObject)Resources.Load("Prefab/CLEAR");
        Instantiate(obj, gameObject.transform.position, Quaternion.identity);
        _goalFlag = true;
    }
}
