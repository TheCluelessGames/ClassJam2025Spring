using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class EnemyCowController : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    private AudioSource audioSource;
    public enum ObjectType {Orange, Purple, Green, White, Red, Blue, Yellow}
    public ObjectType selectedType;
    public Sprite NakedCowHeadSprite, NakedCowBodySprite;
    public SpriteRenderer headRenderer, bodyRenderer;
    public GameObject particlePrefab;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Undress()
    {
        Poof();
        headRenderer.sprite = NakedCowHeadSprite;
        bodyRenderer.sprite = NakedCowBodySprite;
    }

    public void Poof()
    {
        GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        SoundFXManager.Instance.PlaySoundFXClip(sound, transform, 0.5f);
        Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
    }
}
