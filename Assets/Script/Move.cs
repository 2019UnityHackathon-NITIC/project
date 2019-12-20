using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private readonly Rigidbody2D _controller;
    private Vector2 _vector;
    private readonly float _moveSpeed;
    private readonly Vector2 _jumpSpeed;
    private readonly float _maxSpeed;
    public MoveController(float speed, float jump, Rigidbody2D rb, float max)
    {
        _controller = rb;
        _moveSpeed = speed;
        _jumpSpeed = new Vector2(0, jump);
        _maxSpeed = max;
    }
    public void Move(List<int> directions) 
        // direction is 0:front, 1:back
    {
        _vector.x = 0;
        int front = directions.IndexOf(0);
        int back = directions.IndexOf(1);
        if (front != back && (front == -1 || back == -1)){
            if(front == -1){
                if (_controller.velocity.x < -_maxSpeed) return;
                _vector.x -= _moveSpeed;
            }
            else {
                if (_controller.velocity.x > _maxSpeed) return;
                _vector.x += _moveSpeed;
            }
            _controller.velocity += _vector;
        }else _controller.velocity = new Vector2(0, _controller.velocity.y);
    }

    public void Jump(bool flag){
        if (flag){
            _controller.velocity += _jumpSpeed;
        }
    } 
}
