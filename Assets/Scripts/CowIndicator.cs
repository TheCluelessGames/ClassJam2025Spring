
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowIndicator : MonoBehaviour
{
    public Image spriteRenderer;

    public void ChangeColour(Color colour)
    {
        spriteRenderer.gameObject.transform.gameObject.SetActive(true);
        spriteRenderer.color = colour;
    }

    public void Hide()
    {
        spriteRenderer.gameObject.transform.gameObject.SetActive(false);
    }
}
