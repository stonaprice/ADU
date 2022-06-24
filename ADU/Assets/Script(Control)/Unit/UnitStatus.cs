using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitStatus : MonoBehaviour
{
	// ユニットの攻撃力
	[SerializeField] private int attackPower = 1;

	public int AttackPower
	{
		get { return this.attackPower; }
	}
	
	// ユニットの敵探索範囲
	[SerializeField] private float findDistance = 10;

	public float FindDistance
	{
		get { return this.findDistance; }
	}

	// ユニットの攻撃範囲
	[SerializeField] private float attackDistance = 5;

	public float AttackDistance
	{
		get { return this.attackDistance; }
	}
	
	

	
	

	


	// //参考 ( https://gametukurikata.com/program/mystatus )
}
