using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    // Image コンポーネントを格納する変数
    public Image m_Image { get; set; }

    // スプライトオブジェクトを格納する配列
    [FormerlySerializedAs("tite_Sprite")] [SerializeField] private Sprite[] titeSprite;
    public Sprite[] TiteSprite
    {
        get { return this.titeSprite; }
    }
    
    // スプライトオブジェクトを格納する配列
    [FormerlySerializedAs("gakuseisho_Sprite")] [SerializeField] private Sprite[] gakuseishoSprite;
    public Sprite[] GakuseishoSprite
    {
        get { return this.gakuseishoSprite; }
    }

    public int viewNumber { get; set; } = 10000;

    // Start is called before the first frame update
    void Start()
    {
        // Image コンポーネントを取得して変数 m_Image に格納
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<GakuseishoSprite.Length ; i++)
        {
            if (i == viewNumber)
            {
                m_Image.sprite = titeSprite[viewNumber];
                // m_Image.preserveAspect = true;
                //
                // // if (viewNumber == 9 && ReferenceEquals(gameObject.name, "ViewArea1"))
                // if (viewNumber == 9 && gameObject.name == "ViewArea1")
                // {
                //     print("SetNativeSize");
                //     m_Image.preserveAspect = false;
                //     // m_Image.SetNativeSize();
                // }

                viewNumber = 100000;
            }
        }
    }
}