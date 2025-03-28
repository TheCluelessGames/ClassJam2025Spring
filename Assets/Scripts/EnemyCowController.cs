using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCowController : MonoBehaviour
{
    public enum ObjectType {Orange, Purple, Green, White, Red, Blue, Yellow}
    public ObjectType selectedType;
    public Sprite NakedCowSprite;
    private SpriteRenderer spriteRenderer;
    public ObjectType GetObjectType() { return selectedType; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }
    public void Undress()
    {
        spriteRenderer.sprite = NakedCowSprite;
    }
}
