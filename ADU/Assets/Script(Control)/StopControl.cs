using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopControl : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public GameObject cardbutton;
    public GameObject starttext;
    public GameObject CardSelectButton;
    public GameObject TimerObject;

    public void StopMethod()
    {
        TimerObject.SetActive(false);
        starttext.SetActive(false);
        cardbutton.SetActive(false);
        CardSelectButton.SetActive(false);
    }

    public void RestartMethod()
    {
        TimerObject.SetActive(true);
    }
}
