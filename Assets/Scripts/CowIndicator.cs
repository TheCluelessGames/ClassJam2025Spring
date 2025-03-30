
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowIndicator : MonoBehaviour
{
    public Image spriteRenderer;

    public void ChangeColour(Color colour)
    {
        spriteRenderer.color = colour;
    }
}
