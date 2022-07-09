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

    private void Start()
    {
        schoolCreditText = schoolCredit.GetComponent<Text>();
    }

    void Update()
    {
        // テキストの表示を入れ替える
        print("credit = "+currentSchoolCredit);
        schoolCreditText.text = ":" + currentSchoolCredit;
    }
}