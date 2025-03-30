using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FluffCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    float fluff=0;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void FluffCollected()
    {
        fluff++;
        text.text = ""+fluff +"";
        GlobalVariables.playerScore++;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
