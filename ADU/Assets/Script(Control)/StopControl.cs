using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopControl : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public GameObject gameobject;

    public void StopMethod()
    {
        gameobject.SetActive(false);
    }

    public void RestartMethod()
    {
        gameobject.SetActive(true);
    }
}
