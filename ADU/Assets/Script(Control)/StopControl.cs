using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopControl : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;


    public void StopMethod()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(false);

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        //sum.SetActive(false);


        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = false;
    }
}
