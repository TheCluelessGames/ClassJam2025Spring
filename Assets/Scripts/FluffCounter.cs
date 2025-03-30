using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FluffCounter : MonoBehaviour
{
    UIController uIController;
    public TextMeshProUGUI text;
    float fluff=0;
    // Start is called before the first frame update
    void Start()
    {
        uIController = GameObject.Find("UIController").GetComponent<UIController>();
    }

    public void FluffCollected()
    {
        fluff++;
        text.text = ""+fluff;
        if (uIController != null)
        {
            uIController.fluffCount++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
