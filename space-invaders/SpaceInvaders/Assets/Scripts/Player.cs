using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private float _speed = 10.0f;
  [SerializeField] private float _distanceFromEdge = 0.5f;
  private Vector3 _leftEdge;
  private Vector3 _rightEdge;
  
  private void Awake() 
  {
    _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
    _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
  }

  private void Update() 
  {
    Movement();
  }
    private void Movement()
    {
        if (transform.position.x > _rightEdge.x - _distanceFromEdge)
        {
            transform.position = new Vector3(_rightEdge.x - _distanceFromEdge, transform.position.y, 0);
        }
        else if (transform.position.x < _leftEdge.x + _distanceFromEdge)
        {
            transform.position = new Vector3(_leftEdge.x + _distanceFromEdge, transform.position.y, 0);
        }
        else
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0, 0));                 
        }
    }
}
