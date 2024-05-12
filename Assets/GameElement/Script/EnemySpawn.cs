using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public List<Transform> spawnPoint;
    public List<GameObject> spawnGameObject;
    public GameObject gold,finalObject;
    int randPrevious = 0;
    int enemyCount = 0;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 2.5f);
       
    }
    void SpawnEnemy()
    {
        int randx = Random.Range(0, spawnPoint.Count);

        if(randPrevious!=randx)
        {
            int a = 0;
            if(PlayerPrefs.GetInt("Level")>spawnGameObject.Count-1)
            {
                a = spawnGameObject.Count-1;
            }
            else
            {
                a = PlayerPrefs.GetInt("Level");
            }
            GameObject enemy;
            if (enemyCount%50!=0)
            {
                 enemy = Instantiate(spawnGameObject[a], spawnPoint[randx].position, Quaternion.identity);
            }
            else
            {
                 enemy = Instantiate(finalObject, spawnPoint[randx].position, Quaternion.identity);
                Debug.Log("Canavar geliyor..");

            }
             
            enemy.GetComponent<EnemySkills>().source =cam.GetComponent<AudioSource>();
            enemy.GetComponent<EnemySkills>().player = player;
            enemy.GetComponent<EnemySkills>().gold = gold;
            enemyCount++;
            randPrevious = randx;
        }
        else { 
            SpawnEnemy(); 
        }
    }
}
