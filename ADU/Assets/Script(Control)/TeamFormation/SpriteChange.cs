using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    // Image コンポーネントを格納する変数
    private Image m_Image { get; set; }

    // スプライトオブジェクトを格納する配列
    [SerializeField] private Sprite[] tite_Sprite;
    public Sprite[] Tite_Sprite
    {
        get { return this.tite_Sprite; }
    }
    
    // スプライトオブジェクトを格納する配列
    [SerializeField] private Sprite[] gakuseisho_Sprite;
    public Sprite[] Gakuseisho_Sprite
    {
        get { return this.gakuseisho_Sprite; }
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
        for (int i=0; i<Gakuseisho_Sprite.Length ; i++)
        {
            if (i == viewNumber)
            {
                m_Image.sprite = tite_Sprite[viewNumber];

                viewNumber = 100000;
            }
        }
        
    }
}