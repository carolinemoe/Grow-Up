using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy1Prefab;
    [SerializeField] GameObject enemy2Prefab;
    [SerializeField] float enemy1X;
    [SerializeField] float enemy1Y;
    [SerializeField] float enemy2X;
    [SerializeField] float enemy2Y;
    [SerializeField] GameObject player;
    [SerializeField] float xCond1;
    [SerializeField] float xCond2;

    bool spawned1 = false;
    bool spawned2 = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position.x >= xCond1) && spawned1 == false)
        {
            spawnEnemy(1);
        }
        if ((player.transform.position.x >= xCond2) && spawned2 == false)
        {
            spawnEnemy(2);
        }
    }

    void spawnEnemy(int enemyVal)
    {
        if(enemyVal == 1)
        {
            Instantiate(enemy1Prefab, new Vector3(enemy1X, enemy1Y, 0), Quaternion.identity);
            spawned1 = true;
        }
        if (enemyVal == 2)
        {
            Instantiate(enemy2Prefab, new Vector3(enemy2X, enemy2Y, 0), Quaternion.identity);
            spawned2 = true;
        }
    }

}
