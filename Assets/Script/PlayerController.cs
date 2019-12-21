using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private Move _moveController;
    private Rigidbody2D _rb;
    private bool _isGround;
    private bool _canShoot = true;
    private static bool _attackDirectionFlag; // true : front, false, back
    private float _timeFromLastShot = 0;
    private bool _inventoryFlag = false;
    private Animator _animator;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpFlag = 1.5f;
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private float shotDelay = 0.1f;
    private static GameObject spawnPoint;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject player;
    private bool _goalFlag;
    public static bool ShoesFlag = false;
    private bool _shoesFlagManager = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveController = new Move(jumpSpeed, _rb, maxSpeed);
        _attackDirectionFlag = true;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShoesFlag != _shoesFlagManager)
        {
            moveSpeed *= 1.5f;
            _shoesFlagManager = true;
        }
        if (!_canShoot)
        {
            _timeFromLastShot += Time.deltaTime;
            if (_timeFromLastShot > shotDelay)
            {
                _canShoot = true;
                _timeFromLastShot = 0;
            }
        }
        if (Mathf.Abs(_rb.velocity.y) > jumpFlag) _isGround = false;
        else _isGround = true;
        List<int> direction = new List<int> { };
        if (Input.GetKey(KeyCode.D)) direction.Add(0);
        if (Input.GetKey(KeyCode.A)) direction.Add(1);
        DecideState(direction);
        _moveController.MoveCharacter(direction, moveSpeed);
        if (Input.GetKey(KeyCode.Space)) _moveController.Jump(_isGround);
        if (direction.IndexOf(1) != -1 && direction.IndexOf(0) == -1) _attackDirectionFlag = false;
        else if (direction.IndexOf(0) != -1 && direction.IndexOf(1) == -1) _attackDirectionFlag = true;
        if (Input.GetKeyDown(KeyCode.E)) OpenInventory();
    }

    void OpenInventory()
    {
        if (_inventoryFlag)
        {
            Destroy(GameObject.FindGameObjectWithTag("Inventory"));
        }
        else
        {
            Instantiate(inventory);
        }

        _inventoryFlag = !_inventoryFlag;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            
            spawnPoint = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Goal();
        }
        
    }

    void Death()
    {
        Destroy(GameObject.FindGameObjectWithTag("Inventory"));
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity); 
        Destroy(this.gameObject);
    }


    void DecideState(List<int> d)
    {
        if (_isGround)
        {
            if (d.IndexOf(0) != d.IndexOf(1) && ((d.IndexOf(0) != -1 || d.IndexOf(1) != -1)))
            {
                _animator.SetBool("Walk", true);
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
    }
    void Goal()
    {
        if (_goalFlag) return;
        GameObject obj = (GameObject)Resources.Load("Prefab/CLEAR");
        Instantiate(obj, gameObject.transform.position, Quaternion.identity);
        _goalFlag = true;
    }
}
