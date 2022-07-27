using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public System.Action<Invader> killed;
    [SerializeField] public int score = 50;
    [SerializeField] private float _missileSpawnRate = 1.0f;
    [SerializeField] private float _reloadTime = 2.0f;
    [SerializeField] private Transform firePosition;
    private bool _missileActive;

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), _missileSpawnRate, _missileSpawnRate);
    }

    private void MissileAttack()
    {
        if (Random.value < (1.0f / _reloadTime))
        {
            if (!_missileActive && gameObject.activeInHierarchy)
            {
                GameObject obj = MissileShooter.current.GetMissiles();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser") || other.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            if (killed != null)
            {
                killed?.Invoke(this);
            }
            gameObject.SetActive(false);
        }
    }
}
