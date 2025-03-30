using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamUIElement : MonoBehaviour
{
    [SerializeField] GameObject teamName;
    [SerializeField] GameObject closeButton;
    [SerializeField] private AudioClip uiButtonSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowTeam()
    { 
        teamName.SetActive(true);
        closeButton.SetActive(true);
        SoundFXManager.Instance.PlaySoundFXClip(uiButtonSound, transform, 0.5f);

    }

    public void HideTeam()
    {
        teamName.SetActive(false);
        closeButton.SetActive(false);
        SoundFXManager.Instance.PlaySoundFXClip(uiButtonSound, transform, 0.5f);
    }
}
