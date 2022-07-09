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

    public GameObject unit;
    private UnitStatus _unitStatus;
    
    private int ShingakuCost = 10;

    private void Start()
    {
        _degreeText = degree.GetComponent<Text>();
        _shingakuCostText = shingakuCost.GetComponent<Text>();
        
        _scoreManager = schoolCredit.GetComponent<ScoreManager>();
        _unitStatus = unit.GetComponent<UnitStatus>();
    }

    public void PressShingaku()
    {
        if (!firstPush && ShingakuCost < _scoreManager.CurrentSchoolCredit)
        {
            _scoreManager.CurrentSchoolCredit = -ShingakuCost;

            _degreeText.text = "Shushi";
            PowerUp(1.5);
            ShingakuCost *= 2;
            _shingakuCostText.text = "Cost" + ShingakuCost;

            firstPush = true;
        }else if (!secoundPush && ShingakuCost < _scoreManager.CurrentSchoolCredit)
        {
            _scoreManager.CurrentSchoolCredit = -ShingakuCost;

            _degreeText.text = "Hakushi";
            PowerUp(2);

            secoundPush = true;
        }
    }

    private void PowerUp(double reinforce)
    {
        _unitStatus.AttackPower = (int)(_unitStatus.AttackPower * reinforce);
        _unitStatus.MaxHp = (int)(_unitStatus.MaxHp * reinforce);
    }
}
