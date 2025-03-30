using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelPart")
            || collision.CompareTag("Cow") ||
            collision.CompareTag("Bucket") ||
            collision.CompareTag("Obstacle") ||
            collision.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
        }
    }
}
