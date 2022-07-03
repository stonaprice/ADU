using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitStatus : MonoBehaviour
{
    // ユニットのコスト
    [SerializeField] private float unitCost = 1;
    public float UnitCost
    {
        get { return this.unitCost; }
        set => this.unitCost = value;
    }

    // ユニットの攻撃力
    [SerializeField] private int attackPower = 1;
    public int AttackPower
    {
        get { return this.attackPower; }
        set => this.attackPower = value;
    }

    // ユニットの敵探索範囲
    [SerializeField] private float findDistance = 10;
    public float FindDistance
    {
        get { return this.findDistance; }
        set => this.findDistance = value;
    }

    // ユニットの攻撃範囲
    [SerializeField] private float attackDistance = 5;
    public float AttackDistance
    {
        get { return this.attackDistance; }
        set => this.attackDistance = value;
    }
    
    // ユニットの最大HP
    [SerializeField] private int maxHp = 3;
    public int MaxHp
    {
        get { return this.maxHp; }
    }

    


    // //参考 ( https://gametukurikata.com/program/mystatus )
}