using UnityEngine;

public class LevelPart : MonoBehaviour
{
    public Transform[] spawnLocations; // Assign in the prefab
    public GameObject[] objectsToSpawn; // Assign possible objects
    public LevelController levelController;
    private float moveSpeed = 5f;

    void Start()
    {
        SpawnRandomObjects();
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    void SpawnRandomObjects()
    {
        foreach (Transform spawnPoint in spawnLocations)
        {
            if (Random.value > 0.5f) // 50% chance to spawn
            {
                Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], spawnPoint.position, Quaternion.identity, transform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("LevelMiddle"))
        {
            levelController.SpawnLevelPart();
        }
    }
}
