using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    private CanvasGroup fadeCanvas;
    private static UIController instance;
    public float fluffCount;

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Find the fade screen
        fadeCanvas = GameObject.FindWithTag("FadeScreen")?.GetComponent<CanvasGroup>();
        if (fadeCanvas == null)
        {
            Debug.LogError("No UI CanvasGroup found! Make sure you have a UI Image tagged 'FadeScreen'.");
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        yield return StartCoroutine(Fade(1)); // Fade to black
        SceneManager.LoadScene(sceneName);
        yield return StartCoroutine(Fade(-1)); // Fade back in
    }

    private IEnumerator Fade(float targetAlpha)
    {
        if (fadeCanvas == null) yield break;

        float fadeSpeed = 1f; // Adjust fade speed
        while (!Mathf.Approximately(fadeCanvas.alpha, targetAlpha))
        {
            fadeCanvas.alpha = Mathf.MoveTowards(fadeCanvas.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }



    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

