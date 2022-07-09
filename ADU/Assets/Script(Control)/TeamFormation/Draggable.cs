using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
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

    [FormerlySerializedAs("ViewArea(1)")] [SerializeReference] private GameObject viewArea1;
    private SpriteChange _spriteChange1;
    
    [FormerlySerializedAs("SaveUnit")] [SerializeReference] private GameObject saveUnit;
    private SaveUnit _saveUnit;

    public Text CharacterName;
    public Text CharacterText;

    public int _selectNumber = 10000;

    public bool[] FullArea { get; set; } = {false,false,false};

    public void Awake()
    {
        this._self = this.transform;
        this._area = this._self.parent;
        this._root = this._area.parent;
        this._canvasGroup = this.GetComponent<CanvasGroup>();
        
        _spriteChange =  viewArea.GetComponent<SpriteChange>();
        _spriteChange1 =  viewArea1.GetComponent<SpriteChange>();
        
        saveUnit = GameObject.Find("SaveUnit");
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
                _spriteChange1.viewNumber = i;

                switch(i)
                {
                    case 0:
                        CharacterName.text = ("No.3");
                        CharacterText.text = ("仏教学部の少女。\n見るからに謎だが\nとにかく謎に包まれている。\n実際に戦っているのは\n本人ではない\nように見えるが…？");
                        break;

                    case 1:
                        CharacterName.text = ("No.1");
                        CharacterText.text = ("文学部の少女。\n実際はただ通りかかった\nだけだったが、\n何故か巻き込まれた\n可哀相な学生。");
                        break;

                    case 2:
                        CharacterName.text = ("No.8");
                        CharacterText.text = ("医学部の青年。\n正義感が強く、\n現状の打破を狙っていたが\n迂闊に行動できずに居た。\n何も考えていない男が\n来たことは決定打ではなさそうだが\n協力者の多さから\n参戦を決めたのか？"); 
                        break;

                    case 3:
                        CharacterName.text = ("No.2");
                        CharacterText.text = ("獣医学部の獣人(?)。\n獣耳が生えているが\nそれが本物かどうかは不明。\n獣の権利は\n特に脅かされていないが\n医学部繋がりで参戦。\n");
                        break;

                    case 4:
                        CharacterName.text = ("No.4");
                        CharacterText.text = ("看護学部の少女。\nあまり深く考えてはいないが\n面白そうなので\n参戦した。\n注射器を持っているが\n殺傷道具としてしか\n使用経験はない。");
                        break;

                    case 5:
                        CharacterName.text = ("No.6");
                        CharacterText.text = ("経済学部の青年。\n持ち前の狡猾さで\n密かに反抗していたが\nここまで捕まらずに来た。\nオタクの人脈が\n存外広かったため\n参戦の可能性を仄めかしている。");
                        break;

                    case 6:
                        CharacterName.text = ("No.5");
                        CharacterText.text = ("体育学部の青年(?)。\n最強のボディビルダーを目指し、\n筋肉を鍛えていたところ\n皮膚が全て消滅した。\nその結果脳までもが\n筋肉となり\n文字通り脳筋となった。");
                        break;

                    case 7:
                        CharacterName.text = ("No.7");
                        CharacterText.text = ("YouTuberの青年。\n大学を辞め\n動画サイトで小遣いを稼いでいた。\nそれどころではなくなったが\n本人がマスコミ気質で\n行動力があったことから\nついてきた。"); 
                        break;

                    case 8:
                        CharacterName.text = ("No.9");
                        CharacterText.text = ("ごく一般的な少年。\nチーズ牛丼が好きで\nよく食べている。\n日本がこんな状況ではあるが\nオタクと仲が良いため\nなんとなく\n協力してくれている。"); 
                        break;
                }

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