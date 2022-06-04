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
    private int hp;
    // HP表示用UI
    [SerializeField]
    private GameObject HPUI;
    // HP表示用スライダー
    private Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
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

        hp -= value;

        Debug.Log(hp);

        // HP表示用UIのアップデート
        UpdateHPValue();

        // if(Hp <= 0)
        // {
        //     Dead();
        // }
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

    public void SetHp(int hp) {
        this.hp = hp;

        // HP表示用UIのアップデート
        UpdateHPValue();

        // if (hp <= 0) {
        //     // HP表示用UIを非表示にする
        //     HideStatusUI();
        // }
    }

    public int GetHp() {
        return hp;
    }

    public int GetMaxHp() {
        return maxHp;
    }

    public void UpdateHPValue() {
        hpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }
}
