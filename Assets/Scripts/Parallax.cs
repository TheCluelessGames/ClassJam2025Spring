using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float backgroundSpeed = 0.5f;
    public GameObject nextBG;
    public Transform spawnPoint;
    // Start is called before the first frame update
    private void Awake()
    {
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
            GameObject obj = Instantiate(nextBG, spawnPoint.position, Quaternion.identity);
            obj.transform.SetParent(null, true);
        }
    }
}
