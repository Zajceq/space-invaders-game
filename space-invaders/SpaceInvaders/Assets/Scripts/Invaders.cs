using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    [SerializeField] Invader[] _prefabs;
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _columns =8;
    [SerializeField] private float _gapBetweenEnemies = 0.7f;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _distanceFromEdge = 0.5f;
    private Vector3 _direction = Vector2.right;

    private void Awake() 
    {
       for (int row = 0; row < _rows; row++)
       {
            float width = _gapBetweenEnemies * (_columns - 1);
            float height = _gapBetweenEnemies * (_rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * _gapBetweenEnemies), 0.0f);

            for (int column = 0; column < _columns; column++)
            {
                Invader invader = Instantiate(_prefabs[row], transform);
                Vector3 position = rowPosition;
                position.x += column * _gapBetweenEnemies;
                invader.transform.localPosition = position;
            }
       } 
    }
    private void Update() 
    {
        transform.position += _direction * _speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - _distanceFromEdge))
            {
                AdvanceRow();
            }
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + _distanceFromEdge))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }

}
