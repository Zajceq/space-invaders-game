using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public static LaserShooter current;
    public GameObject laser;
    public int laserAmount;
    public bool willGrow;

    public List<GameObject> lasers;

    private void Awake() 
    {
        current = this;
    }
    private void Start() 
    {
        lasers = new List<GameObject>();
        for (int i = 0; i < laserAmount; i++)
        {
            GameObject obj = Instantiate(laser);
            obj.SetActive(false);
            lasers.Add(obj);
        }
    }

    public GameObject GetLasers()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            if (!(lasers[i].activeInHierarchy))   
            {
                return lasers[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(laser);
            lasers.Add(obj);
            return obj;
        }

        return null;
    }
}
