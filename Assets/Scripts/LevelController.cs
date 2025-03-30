using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using static LevelController;

public class LevelController : MonoBehaviour
{
    public enum Season { Spring, Summer, Autumn, Winter }
    public Season currentSeason;
    public GameObject[] levelParts;
    public GameObject[] weather;
    public GameObject[] seasonIcons;
    public Transform spawnPoint; // Where the Level Parts appear
    public float levelSpeed = 5f;
    public int levelPartsPerSeason = 2;
    public int seasonIndex = 1;
    public int seasonType = 0;
    private GameObject lastSpawnedPart, currentWeather,currentSeasonIcon;
    

    void Start()
    {
        currentSeason = LevelController.Season.Spring;
        currentWeather = weather[0];
        currentWeather.SetActive(true);
        currentSeasonIcon = seasonIcons[0];
        currentSeasonIcon.SetActive(true);
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
    public void ChangeWeatherAndSeasonIcon()
    {
        currentWeather.SetActive(false);
        currentSeasonIcon.SetActive(false);
        switch (currentSeason)
        {
            case LevelController.Season.Spring:
                currentWeather = weather[0];
                currentSeasonIcon = weather[0];
                break;
            case LevelController.Season.Summer:
                currentWeather = weather[1];
                currentSeasonIcon = weather[1];
                break;
            case LevelController.Season.Autumn:
                currentWeather = weather[2];
                currentSeasonIcon = weather[2];
                break;
            case LevelController.Season.Winter:
                currentSeasonIcon = weather[3];
                currentWeather = weather[3];
                break;
        }
        currentWeather.SetActive(true);
        currentSeasonIcon.SetActive(true);
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
