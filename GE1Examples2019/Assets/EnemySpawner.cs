using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int enemyNumber = 5;
    public float range = 20;
    
    bool spawning;
    IEnumerator constantSpawn;
    // Start is called before the first frame update
    void Start()
    {
        constantSpawn = ConstantSpawn();
        spawning = true;
        StartCoroutine(constantSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        int tanks = GameObject.FindGameObjectsWithTag("Tank").Length;
        if (tanks > enemyNumber && spawning == true)
        {
            spawning = false;
            StopCoroutine(constantSpawn);
        }
        else if(tanks <= enemyNumber && spawning == false)
        {
            spawning = true;
            StartCoroutine(constantSpawn);
            //Debug.Log("Hey!");
        }
    }

    IEnumerator ConstantSpawn()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnEnemy()
    {
        Vector3 position = (new Vector3(Random.Range(-range, range), 5, Random.Range(-range, range)));
        Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        GameObject enemy = Instantiate(this.enemy, position, rotation);
        enemy.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);

        enemy.GetComponent<Renderer>().material.color = new Color(0.6f, 0.3f, 1.0f);
        enemy.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.6f, 0.3f, 1.0f);

        enemy.AddComponent<Rigidbody>();
        enemy.AddComponent<EnemyDestroy>();
    }
}
