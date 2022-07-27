using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShooter : MonoBehaviour
{
    public static MissileShooter current;
    public GameObject missile
    ;
    public int missileAmount;
    public bool willGrow;

    public List<GameObject> missiles;

    private void Awake() 
    {
        current = this;
    }
    private void Start() 
    {
        missiles = new List<GameObject>();
        for (int i = 0; i < missileAmount; i++)
        {
            GameObject obj = Instantiate(missile);
            obj.SetActive(false);
            missiles.Add(obj);
        }
    }

    public GameObject GetMissiles()
    {
        for (int i = 0; i < missiles.Count; i++)
        {
            if (!(missiles[i].activeInHierarchy))   
            {
                return missiles[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(missile);
            missiles.Add(obj);
            return obj;
        }

        return null;
    }
}
