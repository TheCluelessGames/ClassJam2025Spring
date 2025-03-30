using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class EnemyCowController : MonoBehaviour
{
    public enum ObjectType {Orange, Purple, Green, White, Red, Blue, Yellow}
    public ObjectType selectedType;
    public Sprite NakedCowHeadSprite, NakedCowBodySprite;
    public SpriteRenderer headRenderer, bodyRenderer;
    public GameObject particlePrefab;

    public void Undress()
    {
        Poof();
        headRenderer.sprite = NakedCowHeadSprite;
        bodyRenderer.sprite = NakedCowBodySprite;
    }

    public void Poof()
    {
        GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
    }
}
