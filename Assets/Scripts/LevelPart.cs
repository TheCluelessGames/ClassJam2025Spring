using UnityEngine;

public class LevelPart : MonoBehaviour
{
    public enum ObjectType { Orange, Purple, Green, White, Red, Blue, Yellow }
    public ObjectType selectedType;
    public Transform scenarioSpawn; // Assign in the prefab
    public GameObject[] scenarios; // Assign possible objects
    public GameObject[] transitions; //Assign next season transitions
    private LevelController levelController;
    private BoxCollider2D boxCollider;
    private float moveSpeed = 5f;

    void Awake()
    {
        SpawnScenario();
        levelController = GameObject.Find("Level").GetComponent<LevelController>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        Instantiate(scenarios[Random.Range(0, scenarios.Length)], scenarioSpawn.position, Quaternion.identity);
    }
    public void SpawnTransition(LevelController.Season season)
    {
        boxCollider.offset = new Vector3(28.25326f, -1.306529f, 0f);
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
        Instantiate(transitions[spawnNumber], scenarioSpawn.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            levelController.SpawnLevelPart();
        }
        if (collision.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
