using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] easyEnemies;
    [SerializeField] private GameObject[] hardEnemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnDelayTime;

    // Use this for initialization
    public void OnStart()
    {
        StartCoroutine(EnemyGenerateCoroutine());
    }

    private IEnumerator EnemyGenerateCoroutine()
    {
        while (!GameManager.isGameOver)
        {
            int randNumEnemy = Random.Range(0, spawnPoints.Length);
            int randNumLoc = Random.Range(0, spawnPoints.Length);
            float randSpawnTime = Random.Range((float)spawnDelayTime - 1f, spawnDelayTime + 1f);
            var enemy = Instantiate(easyEnemies[randNumEnemy], spawnPoints[randNumLoc].position, Quaternion.identity);
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
            yield return new WaitForSeconds(randSpawnTime);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}