using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHitPoint : MonoBehaviour
{
    // 塔のHP
	[SerializeField]
	private int maxHp;
    // 塔のHP
    // [SerializeField]
    private int currentHp;
    // HP表示用UI
    [SerializeField]
    private GameObject HPUI;
    // HP表示用スライダー
    private Slider hpSlider;

    public BreakDown breakdown;
    public GameClearAnimation GameClearAnimation;
    //public TanbaCutInTest TanbaCutInTest;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 被ダメージ処理
    public void Damage(int value)
    {
        if(value <= 0)
        {
            return;
        }

        currentHp -= value;

        Debug.Log(currentHp);

        // HP表示用UIのアップデート
        UpdateHPValue();

         if(currentHp <= 0)
         {
            //Dead();
            this.gameObject.GetComponent<Detonator>().Explode();
            breakdown.Explosion();
            GameClearAnimation.TyoKaiSyoBun();
            //TanbaCutInTest.Cutin();
            
         }
    }

    //武器に触れたらダメージ
    protected void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.CompareTag("PlayerTower")){
            if (collision.gameObject.CompareTag("EnemyWeapon")){
                int value = 1;
                Damage(value);
            }
        }
        else if(this.gameObject.CompareTag("EnemyTower")){
            if (collision.gameObject.CompareTag("PlayerWeapon")){
                int value = 1;
                Damage(value);
            }
        }
    }

    public void SetCurrentHp(int currentHp) {
        this.currentHp = currentHp;

        // HP表示用UIのアップデート
        UpdateHPValue();

        // if (currentHp <= 0) {
        //     // HP表示用UIを非表示にする
        //     HideStatusUI();
        // }
    }

    public int GetCurrentHp() {
        return currentHp;
    }

    public int GetMaxHp() {
        return maxHp;
    }

    public void UpdateHPValue() {
        hpSlider.value = (float)GetCurrentHp() / (float)GetMaxHp();
    }
}
