using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreSceneController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        text.text = GlobalVariables.playerScore+"";
    }
}
