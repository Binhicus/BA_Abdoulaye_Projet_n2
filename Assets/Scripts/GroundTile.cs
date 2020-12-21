using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public List<GameObject> obstaclePrefab = new List<GameObject>();
    public bool isRandomized;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 8);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        int index = isRandomized ? Random.Range(0, obstaclePrefab.Count) : 0;
        if (obstaclePrefab.Count > 0)
        {
            Instantiate(obstaclePrefab[index], spawnPoint.position, Quaternion.identity, transform);
        }
        
    }
}
