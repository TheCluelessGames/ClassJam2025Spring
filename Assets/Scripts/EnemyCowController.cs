using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class EnemyCowController : MonoBehaviour
{
    public enum ObjectType {Orange, Purple, Green, White, Red, Blue, Yellow}
    public ObjectType selectedType;
    public Sprite NakedCowSprite;
    private SpriteRenderer spriteRenderer;
    public GameObject particlePrefab;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }
    public void Undress()
    {
        Poof();
        spriteRenderer.sprite = NakedCowSprite;
    }

    public void Poof()
    {
        GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
    }
}
