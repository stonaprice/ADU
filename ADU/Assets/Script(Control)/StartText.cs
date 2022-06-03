using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject sum;
    public SummonUnit summonUnit;
    public CostControl costControl;

    private void Start()
    {
        //?申?申?申?申?申?申?申\?申?申?申��鐃�?申?申
        this.gameObject.SetActive(false);

        //?申{?申^?申?申?申?申?申\?申?申?申��鐃�?申?申
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        sum.SetActive(false);

        //?申X?申N?申?申?申v?申g?申��鐃�?申?申?申?申?申i?申?申?申?申?申?申��鐃�?申��鐃�?申���?申��鐃�?申���?申��j
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = false;

       /*?申{?申^?申?申?申��A?申j?申?申?申[?申V?申?申?申?申?申��鐃渋�鐃�?申?申?申?申
        GameObject buttonObj1 = GameObject.Find("Button1");
        ButtonAnimation buttonAnime = button1.GetComponent<ButtonAnimation>();
        buttonAnime.enabled = false;
       */

        //0.5?申b?申?申��鐃�?申s
        Invoke(nameof(DisplayOn), 0.5f);

        //2.5?申b?申?申��鐃�?申s
        Invoke(nameof(ChangeText), 2.5f);

        //4.5?申b?申?申��鐃�?申s
        Invoke(nameof(DisplayOff), 4.5f);
    }

    void DisplayOn()
    {
        //?申I?申u?申W?申F?申N?申g?申?申\?申?申?申?申?申?申
        this.gameObject.SetActive(true);
    }

    void ChangeText()
    {
        //?申?申?申?申?申?申��X
        Text.text = "START!!";
        //?申?申?申?申?申F?申?申��X
        Text.color = Color.red;
    }

    void KusoUIOn(){
        sum.SetActive(true);
    }

    void DisplayOff()
    {
        //?申?申?申?申?申?申\?申?申?申?申?申?申
        this.gameObject.SetActive(false);

        //?申{?申^?申?申?申?申\?申?申?申��鐃�?申?申
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        //Invoke(nameof(KusoUIOn),2.5f);

        //?申X?申N?申?申?申v?申g?申��L?申?申?申?申?申i?申?申?申?申?申?申��J?申j
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = true;

        // summonEnemyUnit
        costControl.SetEnemyCost(10);
        int maxEnemyCost = costControl.GetEnemyCost();
        // for(int i=0;i < maxEnemyCost;i++)
        // {
        //     summonUnit.UnitSummon(true);
        // }
    }
}
