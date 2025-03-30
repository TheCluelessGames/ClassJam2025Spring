using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHoverSoundFX : MonoBehaviour
{
    [SerializeField] private AudioClip uiHoverSound;

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
}
