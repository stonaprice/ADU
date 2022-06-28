using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(CanvasGroup))]
public class Draggable : MonoBehaviour
{
    private Transform _root;
    private Transform _area;
    private Transform _self;
    private CanvasGroup _canvasGroup = null;
    
    [FormerlySerializedAs("ViewArea")] [SerializeReference] private GameObject viewArea;
    private SpriteChange _spriteChange;
    
    [FormerlySerializedAs("SaveUnit")] [SerializeReference] private GameObject saveUnit;
    private SaveUnit _saveUnit;

    public int _selectNumber = 10000;

    public bool[] FullArea { get; set; } = {false,false,false};

    public void Awake()
    {
        this._self = this.transform;
        this._area = this._self.parent;
        this._root = this._area.parent;
        this._canvasGroup = this.GetComponent<CanvasGroup>();
        
        _spriteChange =  viewArea.GetComponent<SpriteChange>();
        _saveUnit =  saveUnit.GetComponent<SaveUnit>();
    }

    public void OnBeginDrag(BaseEventData eventData)
    {
        // ドラッグできるよういったん DropArea の上位に移動する
        this._self.SetParent(this._root);

        // UI 機能を一時的無効化
        this._canvasGroup.blocksRaycasts = false;
        
        // カードイラストを表示
        CardCheck();
    }

    public void OnDrag(BaseEventData eventData)
    {
        this._self.localPosition = GetLocalPosition(((PointerEventData)eventData).position, this.transform);
    }

    private static Vector3 GetLocalPosition(Vector3 position, Transform transform)
    {
        // 画面上の座標 (Screen Point) を RectTransform 上のローカル座標に変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            position,
            Camera.main,
            out var result);
        return new Vector3(result.x, result.y, 0);
    }

    public void OnEndDrag(BaseEventData eventData)
    {
        // ドロップ地点に DropAra があったらそこに入れる
        var dropArea = GetRaycastArea((PointerEventData)eventData);
        if (dropArea != null)
        {
            // this._area = dropArea.transform;
            
            if (dropArea.name.Contains("SetArea"))
            {
                // カードイラストを表示
                CardCheck();

                if (dropArea.name.Contains("0") && !FullArea[0])
                {
                    this._area = dropArea.transform;

                    SaveCard(0);
                    
                    Debug.Log("SetArea1");
                }else if (dropArea.name.Contains("1") && !FullArea[1]) 
                {
                    this._area = dropArea.transform;

                    SaveCard(1);

                    Debug.Log("SetArea2");
                }else if (dropArea.name.Contains("2") && !FullArea[2])
                {
                    this._area = dropArea.transform;

                    SaveCard(2);

                    Debug.Log("SetArea3");
                }
            }else
            {
                this._area = dropArea.transform;
            }
        }
        this._self.SetParent(this._area);

        // UI 機能を復元
        this._canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// イベント発生地点の DropArea を取得する
    /// </summary>
    /// <param name="eventData">イベントデータ</param>
    /// <returns>DropArea</returns>
    private static DropArea GetRaycastArea(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Select(x => x.gameObject.GetComponent<DropArea>())
            .FirstOrDefault(x => x != null);
    }

    private void CardCheck()
    {
        for (int i=0; i<_spriteChange.GakuseishoSprite.Length; i++)
        {
            if (this.gameObject.GetComponent<Image>().sprite == _spriteChange.GakuseishoSprite[i])
            {
                // Debug.Log(i);
                _spriteChange.viewNumber = i;

                return;
            }
        }
    }

    public void SaveCard(int n)
    {
        for (int i=0; i<_spriteChange.GakuseishoSprite.Length; i++)
        {
            if (this.gameObject.GetComponent<Image>().sprite == _spriteChange.GakuseishoSprite[i])
            {
                // Debug.Log(i);
                // _saveUnit.selectedArea = n;
                // _saveUnit.selectedNumber = i;
                _saveUnit.selectedUnit[n] = _saveUnit.UnitPrefab[i];
                _saveUnit.selectedSprite[n] = this.GetComponent<Image>().sprite;

                return;
            }
        }
    }
}