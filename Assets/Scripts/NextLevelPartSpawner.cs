using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPartSpawner : MonoBehaviour
{
    LevelController levelController;

    private void Awake()
    {
        levelController = GameObject.Find("Level").GetComponent<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelController.SpawnLevelPart();
            levelController.ChangeWeatherAndSeasonIcon();
        }
    }
}
