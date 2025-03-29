using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using static LevelController;

public class LevelController : MonoBehaviour
{
    public enum Season { Spring, Summer, Autumn, Winter }
    public Season currentSeason;
    public GameObject[] levelParts;
    public Transform spawnPoint; // Where the Level Parts appear
    public float levelSpeed = 5f;
    public int levelPartsPerSeason = 5;

    private Queue<GameObject[]> seasonQueue;
    private int seasonIndex = 1;
    private int seasonType = 0;
    private GameObject lastSpawnedPart;

    void Start()
    {
        currentSeason = LevelController.Season.Spring;
    }

    void Update()
    {
        
    }

    
    public void SpawnLevelPart()
    {
        switch (currentSeason)
        {
            case LevelController.Season.Spring:
                seasonType = 0;
                break;
            case LevelController.Season.Summer:
                seasonType = 1;
                break;
            case LevelController.Season.Autumn:
                seasonType = 2;
                break;
            case LevelController.Season.Winter:
                seasonType = 3;
                break;
        }
        seasonIndex++;
        lastSpawnedPart = Instantiate(levelParts[seasonType], spawnPoint.position, Quaternion.identity);
        if(seasonIndex >= levelPartsPerSeason)
        {
            lastSpawnedPart.GetComponent<LevelPart>().SpawnTransition(currentSeason);
            lastSpawnedPart.GetComponent<LevelPart>().SetSpeed(levelSpeed);
            NextSeason();
            seasonIndex = 0;
        }
    }

    private void NextSeason()
    {
        switch (currentSeason)
        {
            case LevelController.Season.Spring:
                currentSeason = LevelController.Season.Summer;
                break;
            case LevelController.Season.Summer:
                currentSeason = LevelController.Season.Autumn;
                break;
            case LevelController.Season.Autumn:
                currentSeason = LevelController.Season.Winter;
                break;
            case LevelController.Season.Winter:
                currentSeason = LevelController.Season.Spring;
                break;
        }
    }

}
