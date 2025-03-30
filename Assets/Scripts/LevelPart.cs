using UnityEngine;

public class LevelPart : MonoBehaviour
{
    public Transform scenarioSpawn,transitionSpawn; // Assign in the prefab
    public GameObject[] scenarios; // Assign possible objects
    public GameObject[] transitions; //Assign next season transitions
    public GameObject nextLevelSpawner,currentScenario,transition;
    private float moveSpeed = 5f;

    void Awake()
    {
        SpawnScenario();        
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    private void SpawnScenario()
    {
        currentScenario = Instantiate(scenarios[Random.Range(0, scenarios.Length)], scenarioSpawn.position, Quaternion.identity);
        currentScenario.transform.SetParent(scenarioSpawn);
    }
    public void SpawnTransition(LevelController.Season season)
    {
        int spawnNumber =0;
        switch (season)
        {
            case LevelController.Season.Spring:
                spawnNumber = 0;
                break;
            case LevelController.Season.Summer:
                spawnNumber = 1;
                break;
            case LevelController.Season.Autumn:
                spawnNumber = 2;
                break;
            case LevelController.Season.Winter:
                spawnNumber = 3;
                break;
        }
        transition = Instantiate(transitions[spawnNumber], scenarioSpawn.position, Quaternion.identity);
        transition.transform.SetParent(transitionSpawn);
        transition.transform.position = transitionSpawn.position;
        nextLevelSpawner.SetActive(false);
    }
}
