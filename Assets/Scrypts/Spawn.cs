using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;
    public int waves;
    int i;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

   void SpawnEnemy()
    {
        for (i = Random.Range(1, 3); i < waves; i++)
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8.3f, 8.3f), 7, 0), Quaternion.identity);

           
        
    }
}
