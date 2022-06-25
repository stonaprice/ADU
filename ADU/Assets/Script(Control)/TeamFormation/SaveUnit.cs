using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUnit : MonoBehaviour
{
    public static SaveUnit instance = null;
    
    // スプライトオブジェクトを格納する配列
    [SerializeField] private GameObject[] unitPrefab;
    public GameObject[] UnitPrefab
    {
        get { return this.unitPrefab; }
    }
    
    public GameObject[] selectedUnit = new GameObject[3];
    public Sprite[] selectedSprite = new Sprite[3];
    
    private void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
