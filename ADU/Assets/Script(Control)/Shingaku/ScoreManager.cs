using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 単位数を表示しているオブジェクト
    [SerializeField] private GameObject schoolCredit = null; // Textオブジェクト
    // 現在の習得単位数
    private int currentSchoolCredit = 0;
    public int CurrentSchoolCredit
    {
        get { return this.currentSchoolCredit; }
        set => this.currentSchoolCredit = value;
    }

    private Text schoolCreditText;

    [SerializeField] private GameObject[] ShingakuButton = new GameObject[3];
    // private ShingakuButton[] _shingakuButton = new ShingakuButton[3];

    private void Start()
    {
        schoolCreditText = schoolCredit.GetComponent<Text>();

        // for (int i = 0; i < 3; i++)
        // {
        //     _shingakuButton = ShingakuButton[i].GetComponent<ShingakuButton>();
        // }
    }

    void Update()
    {
        // テキストの表示を入れ替える
        // print("credit = "+currentSchoolCredit);
        schoolCreditText.text = ":" + currentSchoolCredit;

        for (int i = 0; i < 3; i++)
        {
            if (ShingakuButton[i].GetComponent<ShingakuButton>().requiredCost <= CurrentSchoolCredit)
            {
                ShingakuButton[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                ShingakuButton[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}