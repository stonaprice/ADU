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
        //文字を非表示にする
        this.gameObject.SetActive(false);

        //ボタンを非表示にする
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        sum.SetActive(false);

        //スクリプトの無効化（操作をできないようにするため）
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = false;

       /*ボタンのアニメーションのやつ無効化
        GameObject buttonObj1 = GameObject.Find("Button1");
        ButtonAnimation buttonAnime = button1.GetComponent<ButtonAnimation>();
        buttonAnime.enabled = false;
       */

        //0.5秒後に実行
        Invoke(nameof(DisplayOn), 0.5f);

        //2.5秒後に実行
        Invoke(nameof(ChangeText), 2.5f);

        //4.5秒後に実行
        Invoke(nameof(DisplayOff), 4.5f);
    }

    void DisplayOn()
    {
        //オブジェクトを表示する
        this.gameObject.SetActive(true);
    }

    void ChangeText()
    {
        //文字を変更
        Text.text = "START!!";
        //文字色を変更
        Text.color = Color.red;
    }

    void DisplayOff()
    {
        //文字を表示する
        this.gameObject.SetActive(false);

        //ボタンを表示にする
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        sum.SetActive(true);

        //スクリプトの有効化（操作を再開）
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = true;

        // summonEnemyUnit
        costControl.SetEnemyCost(10);
        int maxEnemyCost = costControl.GetEnemyCost();
        for(int i=0;i < maxEnemyCost;i++)
        {
            summonUnit.UnitSummon(true);
        }
    }
}
