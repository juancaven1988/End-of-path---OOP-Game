using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] spawnPoints;
    int wave = 1;
    int enemyCount;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(enemyCount == 0)
        {
            SpawnEnemyWave();
        }
    }

    void SpawnEnemyWave()
    {
        for(int i = 0; i < wave; i++)
        {
            int enemytoSpawn = Random.Range(0, enemies.Length);

            if(enemies[enemytoSpawn].name == "Enemypider")
            {
                Instantiate(enemies[enemytoSpawn], spawnPoints[0]);
            }
            else
            {
                Instantiate(enemies[enemytoSpawn], spawnPoints[Random.Range(1,3)]);
            }
        }

        wave++;
    }


}
