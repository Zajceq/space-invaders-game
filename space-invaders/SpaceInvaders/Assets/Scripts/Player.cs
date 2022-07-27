using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _distanceFromEdge = 0.5f;
    private bool _laserActive;
    private Vector3 _leftEdge;
    private Vector3 _rightEdge;
    public System.Action killed;
    [SerializeField] private Transform firePosition;


    private void Update()
    {
        Movement();
        Shoot();
    }
    private void Movement()
    {
        _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
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

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_laserActive)
            {
                GameObject obj = LaserShooter.current.GetLasers();
                if (obj == null)
                {
                    return;
                }
                obj.transform.position = firePosition.position;
                obj.transform.rotation = firePosition.rotation;
                obj.SetActive(true);
            }
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") || other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            if(killed != null)
            {
                killed.Invoke();
            }
        }
    }
}
