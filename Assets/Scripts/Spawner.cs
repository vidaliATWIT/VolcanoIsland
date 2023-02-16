using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float timeBetweenSpawns;
    public float maxSpawnTime;
    public float minSpawnTime;
    public float decreaseAmount;

    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        //guard
        if (GameManager.instance().gameOverCanvas.gameObject.activeSelf) 
        {
            return;
        }
        //basic spawner
        if (spawnTimer<=0)
        {
            Vector3 player_pos = GameManager.instance().getPlayerVector();
            print("Player pos at:  " + player_pos);

            //do the spawn
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            float xPos = Random.Range(-8.5f, 8.5f);
            Vector3 location = new Vector3(xPos, 5.5f, 0.0f);
            //print("Spawn fireball");
            Instantiate(enemy, location, Quaternion.identity);


            //difficulty stuff
            if (timeBetweenSpawns > minSpawnTime)
            {
                timeBetweenSpawns -= decreaseAmount;
            }
            //reset timer
            spawnTimer = timeBetweenSpawns;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    public void reset()
    {
        timeBetweenSpawns = maxSpawnTime;
        spawnTimer = timeBetweenSpawns;
    }
}
