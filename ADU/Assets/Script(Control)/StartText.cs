using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public GameObject cardbutton;
    public SummonUnit summonUnit;
    public CostControl costControl;
    public GameObject CardSelectButton;
    //public GameObject sum;

    public void PlayStart()
    {
        //?��?��?��?��?��?��?��\?��?��?��ɂ�?��?��
        this.gameObject.SetActive(false);

        //?��{?��^?��?��?��?��?��\?��?��?��ɂ�?��?��
        cardbutton.SetActive(false);
        //sum.SetActive(false);

        //?��X?��N?��?��?��v?��g?��̖�?��?��?��?��?��i?��?��?��?��?��?��ł�?��Ȃ�?��悤?��ɂ�?��邽?��߁j
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = false;

       /*?��{?��^?��?��?��̃A?��j?��?��?��[?��V?��?��?��?��?��̂��?��?��?��?��
        GameObject buttonObj1 = GameObject.Find("Button1");
        ButtonAnimation buttonAnime = button1.GetComponent<ButtonAnimation>();
        buttonAnime.enabled = false;
       */

        //0.5?��b?��?��Ɏ�?��s
        Invoke(nameof(DisplayOn), 0.5f);

        //2.5?��b?��?��Ɏ�?��s
        Invoke(nameof(ChangeText), 2.5f);

        //4.5?��b?��?��Ɏ�?��s
        Invoke(nameof(DisplayOff), 4.5f);
    }

    void DisplayOn()
    {
        //?��I?��u?��W?��F?��N?��g?��?��\?��?��?��?��?��?��
        this.gameObject.SetActive(true);
    }

    void ChangeText()
    {
        //?��?��?��?��?��?��ύX
        Text.text = "START!!";
        //?��?��?��?��?��F?��?��ύX
        Text.color = Color.red;
        CardSelectButton.SetActive(true);
    }

    void DisplayOff()
    {
        //?��?��?��?��?��?��\?��?��?��?��?��?��
        this.gameObject.SetActive(false);

        //?��{?��^?��?��?��?��\?��?��?��ɂ�?��?��
        cardbutton.SetActive(true);
        //Invoke(nameof(KusoUIOn),2.5f);

        //?��X?��N?��?��?��v?��g?��̗L?��?��?��?��?��i?��?��?��?��?��?��ĊJ?��j
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = true;

        // summonEnemyUnit
        costControl.SetEnemyCost(10);
        float maxEnemyCost = costControl.GetEnemyCost();
        for(int i=0;i < maxEnemyCost;i++)
        {
            summonUnit.UnitSummon(true);
        }
    }
}
