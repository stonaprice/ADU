using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DropArea : MonoBehaviour
{
    private GameObject child;
    private GameObject saveUnit;
    private SaveUnit _saveUnit;

    [SerializeField] private GameObject[] cards;
    [FormerlySerializedAs("_draggable")] [SerializeField] private Draggable[] draggable;
    
    private void Start()
    {
        saveUnit = GameObject.Find("SaveUnit");
        _saveUnit = saveUnit.GetComponent<SaveUnit>();

        // Debug.Log("card 長さ"+cards.Length);
        for (int i = 0; i < cards.Length; i++)
        {
            // Debug.Log(cards[i]);
            draggable[i] = cards[i].GetComponent<Draggable>();
        }
    }

    private void Update()
    {
        //objAの子オブジェクトの数を取得する
        int _ChildCount = this.transform.childCount;

        if (this.name.Equals("SelectArea"))
        {
            // Debug.Log("SelectArea");
        }
        // SetAreaに学生証がセットされていないとき
        else if (_ChildCount == 0)
        {
            if (this.name.Contains("0"))
            {
                // SetAreaに学生証をセット出来るようにする
                NullArea(0);
                SetFullArea(0, false);
            }else if (this.name.Contains("1"))
            {
                // SetAreaに学生証をセット出来るようにする
                NullArea(1);
                SetFullArea(1, false);
            }else if (this.name.Contains("2"))
            {
                // SetAreaに学生証をセット出来るようにする
                NullArea(2);
                SetFullArea(2, false);
            }
        }
        // エリアにカードがセットされているとき
        else if (1 <= _ChildCount)
        {
            child = transform.GetChild(0).gameObject;

            if (this.name.Contains("0"))
            {
                SetCard(0, child);
                SetFullArea(0, true);
            }else if (this.name.Contains("1"))
            {
                SetCard(1, child);
                SetFullArea(1, true);
            }else if (this.name.Contains("2"))
            {
                SetCard(2, child);
                SetFullArea(2, true);
            }
        }
    }

    // 学生証がセットされていないとき
    private void NullArea(int areaNumber)
    {
        _saveUnit.selectedUnit[areaNumber] = null;
        _saveUnit.selectedSprite[areaNumber] = null;
    }

    private void SetCard(int areaNumber, GameObject childObj)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (ReferenceEquals(childObj, cards[i]))
            {
                draggable[i].SaveCard(areaNumber);
            }
        }
    }
    
    // 学生証がセットされているかどうかを渡す
    private void SetFullArea(int areaNumber, bool fullarea)
    {
        // draggable[1].FullArea[areaNumber] = fullarea;

        for (int i = 0; i < cards.Length; i++)
        {
            draggable[i].FullArea[areaNumber] = fullarea;
        }
    }
}