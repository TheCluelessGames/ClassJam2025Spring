using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelController : MonoBehaviour
{
    public GameObject[] levelParts;
    public Transform spawnPoint; // Where the Level Parts appear
    public float levelSpeed = 5f;
    public float backgroundSpeed = 0.5f;
    public GameObject background; // Assign a scrolling background object

    private Queue<GameObject[]> seasonQueue;
    private int seasonIndex = 0;
    private GameObject lastSpawnedPart;

    void Start()
    {
        StartCoroutine(SpawnLevelParts());
    }

    void Update()
    {
        MoveBackground();
    }

    
    public void SpawnLevelPart()
    {

    }
    IEnumerator SpawnLevelParts()
    {
        while (true)
        {
            GameObject[] currentSeason = seasonQueue.Dequeue();
            for (int i = 0; i < 6; i++) // Spawn 6 Level Parts
            {
                SpawnLevelPart(currentSeason[Random.Range(0, currentSeason.Length)]);
                yield return new WaitForSeconds(2f); // Adjust delay between spawns
            }

            if (seasonQueue.Count > 0)
            {
                // Spawn the transition prefab for this season
                SpawnLevelPart(seasonQueue.Dequeue()[0]);
                yield return new WaitForSeconds(2f);
            }

            seasonQueue.Enqueue(currentSeason); // Re-add season to the queue
        }
    }

    void SpawnLevelPart(GameObject prefab)
    {
        lastSpawnedPart = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        LevelPart levelPartScript = lastSpawnedPart.GetComponent<LevelPart>();
        if (levelPartScript != null)
        {
            levelPartScript.SetSpeed(levelSpeed);
        }
    }

    void MoveBackground()
    {
        if (background != null)
        {
            background.transform.Translate(Vector3.left * backgroundSpeed * Time.deltaTime);
        }
    }
}
