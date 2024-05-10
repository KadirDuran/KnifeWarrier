using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<Transform> spawnPoint;
    int randPrevious = 0;
    public GameObject spawnGameObject;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 5f);
    }
    void SpawnEnemy()
    {
        int randx = Random.Range(0, spawnPoint.Count-1);

        if(randPrevious!=randx)
        {
            Instantiate(spawnGameObject,spawnPoint[randx].position,Quaternion.identity);
            randPrevious = randx;
        }
        else { 
            SpawnEnemy(); }
    }
}
