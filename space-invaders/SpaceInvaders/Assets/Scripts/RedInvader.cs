using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedInvader : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _cycleTime = 30f;
    [SerializeField] public int score = 300;
    public System.Action<RedInvader> killed;

    [SerializeField] private int _direction = -1;
    private Vector3 _leftDestination;
    private Vector3 _rightDestination;
    private bool _spawned;

    private void Start()
    {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        Vector3 left = transform.position;
        left.x = leftEdge.x - 1f;
        _leftDestination = left;

        Vector3 right = transform.position;
        right.x = rightEdge.x + 1f;
        _rightDestination = right;

        transform.position = _leftDestination;
        Despawn();
    }

    private void Update()
    {
        if (!_spawned)
        {
            return;
        }

        if (_direction == 1)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;

        if (transform.position.x >= _rightDestination.x)
        {
            Despawn();
        }
    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x <= _leftDestination.x)
        {
            Despawn();
        }
    }

    private void Spawn()
    {
        _direction *= -1;

        if (_direction == 1)
        {
            transform.position = _leftDestination;
        }
        else
        {
            transform.position = _rightDestination;
        }

        _spawned = true;
    }

    private void Despawn()
    {
        _spawned = false;

        if (_direction == 1)
        {
            transform.position = _rightDestination;
        }
        else
        {
            transform.position = _leftDestination;
        }

        Invoke(nameof(Spawn), _cycleTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Despawn();

            if (killed != null)
            {
                killed.Invoke(this);
            }
        }
    }

}
