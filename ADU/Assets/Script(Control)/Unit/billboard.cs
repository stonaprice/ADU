using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour {

	

	void Update () {
		Vector3 p = Camera.main.transform.position;
		p.y = transform.position.y;
		transform.LookAt (p);

		/*
		// 前方の基準となるローカル空間ベクトル
    	[SerializeField] private Vector3 _forward = Vector3.forward;

		// ターゲットへの向きベクトル計算
        var dir = p.position - this.position;

        // ターゲットの方向への回転
        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
        // 回転補正
        var offsetRotation = Quaternion.FromToRotation(_forward, Vector3.forward);

        // 回転補正→ターゲット方向への回転の順に、自身の向きを操作する
        this.rotation = lookAtRotation * offsetRotation;
		*/
	}
}