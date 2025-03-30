using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
    public EnemyCowController.ObjectType type;
    private CowIndicator indicator;
    Color purple = new Color(0.6705883f, 0.3254902f, 0.8862745f);
    Color orange = new Color(0.9294118f, 0.5215687f, 0.3333333f);
    Color green = new Color(0.5568628f, 0.8666667f, 0.4745098f);
    private void Awake()
    {        
        indicator = GameObject.Find("CowIndicator").GetComponent<CowIndicator>();
        switch (type)
        {
            case EnemyCowController.ObjectType.Purple:
                indicator.ChangeColour(purple);
                break;
            case EnemyCowController.ObjectType.Orange:
                indicator.ChangeColour(orange);
                break;
            case EnemyCowController.ObjectType.Green:
                indicator.ChangeColour(green);
                break;
            case EnemyCowController.ObjectType.White:
                indicator.Hide();
                break;

        }
    }
}
