using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;
    public System.Action destroyed;
    private Rigidbody2D rb;

    private void OnEnable() 
    {
        if(rb != null)
        {
            rb.velocity = _direction * _speed;
        }
        Invoke("Disable", 2f);
    }
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = _direction * _speed;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (destroyed != null)
        {
            destroyed.Invoke();
        }
        
        Disable();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
