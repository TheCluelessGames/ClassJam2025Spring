using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LevelController;

public class Parallax : MonoBehaviour
{
    public float backgroundSpeed = 0.5f;
    public Season currentSeason;
    public GameObject[] trees, mountains, fields;
    public GameObject sky;
    private GameObject nextBG;
    public string type;
    public Transform spawnPoint;
    // Start is called before the first frame update
    private void Awake()
    {
        currentSeason = GameObject.Find("Level").GetComponent<LevelController>().currentSeason;
        spawnPoint = GameObject.Find("BackgroundSpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * backgroundSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (type)
            {
                case "Sky":
                    nextBG = sky;
                    break;
                case "Tree":
                    if(currentSeason == LevelController.Season.Spring)
                    {
                        nextBG = trees[0];
                    }
                    if (currentSeason == LevelController.Season.Summer)
                    {
                        nextBG = trees[1];
                    }
                    if (currentSeason == LevelController.Season.Autumn)
                    {
                        nextBG = trees[2];
                    }
                    if (currentSeason == LevelController.Season.Winter)
                    {
                        nextBG = trees[3];
                    }
                    break;
                case "Mountain":
                    if (currentSeason == LevelController.Season.Spring)
                    {
                        nextBG = mountains[0];
                    }
                    if (currentSeason == LevelController.Season.Summer)
                    {
                        nextBG = mountains[1];
                    }
                    if (currentSeason == LevelController.Season.Autumn)
                    {
                        nextBG = mountains[2];
                    }
                    if (currentSeason == LevelController.Season.Winter)
                    {
                        nextBG = mountains[3];
                    }
                    break;
                case "Field":
                    if (currentSeason == LevelController.Season.Spring)
                    {
                        nextBG = fields[0];
                    }
                    if (currentSeason == LevelController.Season.Summer)
                    {
                        nextBG = fields[1];
                    }
                    if (currentSeason == LevelController.Season.Autumn)
                    {
                        nextBG = fields[2];
                    }
                    if (currentSeason == LevelController.Season.Winter)
                    {
                        nextBG = fields[3];
                    }
                    break;
            }
            GameObject obj = Instantiate(nextBG, spawnPoint.position, Quaternion.identity);
            obj.transform.SetParent(null, true);
        }
    }
}
