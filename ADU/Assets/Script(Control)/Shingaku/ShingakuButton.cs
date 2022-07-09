using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ShingakuButton : MonoBehaviour
{
    private bool firstPush = false;
    private bool secoundPush = false;
    
    [SerializeField] private GameObject schoolCredit = null; // Textオブジェクト
    private ScoreManager _scoreManager;

    [SerializeField] private GameObject degree;
    private Text _degreeText;
    
    [SerializeField] private GameObject shingakuCost;
    private Text _shingakuCostText;

    [SerializeField] private GameObject unit;
    public GameObject Unit
    {
        get { return this.unit; }
        set => this.unit = value;
    }

    
    private UnitStatus _unitStatus;

    [FormerlySerializedAs("ShingakuCost")] public int requiredCost = 5;

    private void Start()
    {
        _degreeText = degree.GetComponent<Text>();
        _shingakuCostText = shingakuCost.GetComponent<Text>();
        
        _scoreManager = schoolCredit.GetComponent<ScoreManager>();
        _unitStatus = unit.GetComponent<UnitStatus>();
    }

    public void PressShingaku()
    {
        if (!firstPush && requiredCost <= _scoreManager.CurrentSchoolCredit)
        {
            _scoreManager.CurrentSchoolCredit -= requiredCost;

            _degreeText.text = "修士";
            PowerUp(1.5);
            requiredCost *= 2;
            _shingakuCostText.text = "Cost" + requiredCost;

            firstPush = true;
            gameObject.GetComponent<Button>().interactable = false;
        }else if (!secoundPush && requiredCost <= _scoreManager.CurrentSchoolCredit)
        {
            _scoreManager.CurrentSchoolCredit -= requiredCost;

            _degreeText.text = "博士";
            PowerUp(2);

            secoundPush = true;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    private void PowerUp(double reinforce)
    {
        _unitStatus.AttackPower = (int)(_unitStatus.AttackPower * reinforce);
        _unitStatus.MaxHp = (int)(_unitStatus.MaxHp * reinforce);
    }
}
