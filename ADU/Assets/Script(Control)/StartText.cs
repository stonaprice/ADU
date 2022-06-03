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
        //?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ\?ｿｽ?ｿｽ?ｿｽﾉゑｿｽ?ｿｽ?ｿｽ
        this.gameObject.SetActive(false);

        //?ｿｽ{?ｿｽ^?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ\?ｿｽ?ｿｽ?ｿｽﾉゑｿｽ?ｿｽ?ｿｽ
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        sum.SetActive(false);

        //?ｿｽX?ｿｽN?ｿｽ?ｿｽ?ｿｽv?ｿｽg?ｿｽﾌ厄ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽi?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽﾅゑｿｽ?ｿｽﾈゑｿｽ?ｿｽ謔､?ｿｽﾉゑｿｽ?ｿｽ驍ｽ?ｿｽﾟ）
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = false;

       /*?ｿｽ{?ｿｽ^?ｿｽ?ｿｽ?ｿｽﾌア?ｿｽj?ｿｽ?ｿｽ?ｿｽ[?ｿｽV?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽﾌゑｿｽﾂ厄ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ
        GameObject buttonObj1 = GameObject.Find("Button1");
        ButtonAnimation buttonAnime = button1.GetComponent<ButtonAnimation>();
        buttonAnime.enabled = false;
       */

        //0.5?ｿｽb?ｿｽ?ｿｽﾉ趣ｿｽ?ｿｽs
        Invoke(nameof(DisplayOn), 0.5f);

        //2.5?ｿｽb?ｿｽ?ｿｽﾉ趣ｿｽ?ｿｽs
        Invoke(nameof(ChangeText), 2.5f);

        //4.5?ｿｽb?ｿｽ?ｿｽﾉ趣ｿｽ?ｿｽs
        Invoke(nameof(DisplayOff), 4.5f);
    }

    void DisplayOn()
    {
        //?ｿｽI?ｿｽu?ｿｽW?ｿｽF?ｿｽN?ｿｽg?ｿｽ?ｿｽ\?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ
        this.gameObject.SetActive(true);
    }

    void ChangeText()
    {
        //?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽﾏ更
        Text.text = "START!!";
        //?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽF?ｿｽ?ｿｽﾏ更
        Text.color = Color.red;
    }

    void KusoUIOn(){
        sum.SetActive(true);
    }

    void DisplayOff()
    {
        //?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ\?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ
        this.gameObject.SetActive(false);

        //?ｿｽ{?ｿｽ^?ｿｽ?ｿｽ?ｿｽ?ｿｽ\?ｿｽ?ｿｽ?ｿｽﾉゑｿｽ?ｿｽ?ｿｽ
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        //Invoke(nameof(KusoUIOn),2.5f);

        //?ｿｽX?ｿｽN?ｿｽ?ｿｽ?ｿｽv?ｿｽg?ｿｽﾌ有?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽi?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽﾄ開?ｿｽj
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
