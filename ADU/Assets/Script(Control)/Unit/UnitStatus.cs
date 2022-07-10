using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
    [SerializeField] private int gakushiAttackPower;
    private int shushiAttackPower;
    private int hakushiAttackPower;

    private int attackPower = 1;
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
    [SerializeField] private int gakushiMaxHp = 3;
    private int shushiMaxHp;
    private int hakushiMaxHp;

    private int maxHp = 3;
    public int MaxHp
    {
        get { return this.maxHp; }
        set => this.maxHp = value;
    }

    // ユニットの移動速度
    [SerializeField] private int moveSpeed = 10;
    public int MoveSpeed
    {
        get { return this.moveSpeed; }
    }

    [SerializeField] private int degree;
    public int Degree
    {
        get { return this.degree; }
        set => this.degree = value;
    }

    private void Start()
    {
        shushiAttackPower = (int)(gakushiAttackPower * 1.5);
        hakushiAttackPower = shushiAttackPower * 2;
        
        shushiMaxHp = (int)(gakushiMaxHp * 1.5);
        hakushiMaxHp = shushiMaxHp * 2;

        switch (degree)
        {
            case 0: // 学士
                print("gakushi");
                attackPower = gakushiAttackPower;
                maxHp = gakushiMaxHp;
                break;
            case 1: // 修士
                print("shushi");
                attackPower = shushiAttackPower;
                maxHp = shushiMaxHp;
                break; 
            case 2: // 博士
                print("hakushi");
                attackPower = hakushiAttackPower;
                maxHp = hakushiMaxHp;
                break;
        }
            
        if (gameObject.CompareTag("PlayerUnit") || gameObject.CompareTag("EnemyUnit"))
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = moveSpeed;
        }
    }

    // //参考 ( https://gametukurikata.com/program/mystatus )
}