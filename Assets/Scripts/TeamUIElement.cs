using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamUIElement : MonoBehaviour
{
    [SerializeField] GameObject teamName;
    [SerializeField] GameObject closeButton;

    public void ShowTeam()
    { 
        teamName.SetActive(true);
        closeButton.SetActive(true);
    }

    public void HideTeam()
    {
        teamName.SetActive(false);
        closeButton.SetActive(false);
    }
}
