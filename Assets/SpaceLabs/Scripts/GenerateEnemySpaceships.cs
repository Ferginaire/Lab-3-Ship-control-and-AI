using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Generate enemy spaceships
 */
public class GenerateEnemySpaceships : MonoBehaviour
{
    public int numberOfEnemies;
    public GameObject[] enemyPrefabs;
    public int numberOfSpawners;
    public int radius;

    private List<GameObject> spawners = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(GenerateSpawners());
    }

    IEnumerator GenerateSpawners()
    { 
        for (int i = 0; i <= numberOfSpawners; i++)
        {
            GameObject newSpawner = new GameObject();
            newSpawner.name = "Spawner " + i; 
            newSpawner.tag = "spawner";

            newSpawner.transform.SetParent(this.transform, false);
            newSpawner.transform.localPosition = Random.insideUnitSphere * radius;
            spawners.Add(newSpawner);
        }

        yield return StartCoroutine(GenerateEnemies());
    }

    IEnumerator GenerateEnemies()
    {
        GameObject selectedEnemy;
        GameObject selectedSpawner;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Randomly select an enemy prefab from the pool and select a spawner to spawn it
            selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            selectedEnemy = Instantiate(selectedEnemy);

            selectedSpawner = spawners[Random.Range(0, spawners.Count)];
            selectedEnemy.transform.SetParent(selectedSpawner.transform, false);

            yield return new WaitForSeconds(5);
        }
    }
}
