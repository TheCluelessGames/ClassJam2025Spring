using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHoverSoundFX : MonoBehaviour
{
    [SerializeField] private AudioClip uiHoverSound;
    [SerializeField] private AudioClip uiClickSound;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void HoverSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(uiHoverSound, transform, 0.25f);
    }

    public void UIButtonClicked()
    {
        //this in mainly used in the game scene :`D
        SoundFXManager.Instance.PlaySoundFXClip(uiClickSound, transform, 0.5f);

    }
}
