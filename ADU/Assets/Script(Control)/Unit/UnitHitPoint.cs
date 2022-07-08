using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UnitHitPoint : MonoBehaviour
{
    // ユニットの最大HP
	// [SerializeField]
	private int maxHp;
    // ユニットの現在HP
	// [SerializeField]
	private int currentHp;
    // HP表示用UI
    [SerializeField]
    private GameObject HPUI;
    // HP表示用スライダー
    private Slider hpSlider;
    // UnitStatusからmaxHPを持ってくる準備
    [SerializeField]
    private UnitStatus unitStatus;

    // Start is called before the first frame update
    void Start()
    {
        // UnitStatusからHPを持ってくる
        unitStatus = this.GetComponent<UnitStatus>();
        this.maxHp = unitStatus.MaxHp;
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

        // HP表示用UIのアップデート
        UpdateHPValue();

        if(currentHp <= 0)
        {
            Dead();
        }
    }

  // 死亡時の処理
    void Dead()
    {
        Destroy(gameObject);
    }

    //武器に触れたらダメージ
    protected void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.CompareTag("PlayerUnit")){
            if (collision.gameObject.CompareTag("EnemyWeapon")){
                // 接触した弾を削除する
                Destroy(collision.gameObject);
                
                int value = collision.gameObject.GetComponent<HommingBullet>().attackPower;
                Damage(value);
            }
        }
        else if(this.gameObject.CompareTag("EnemyUnit")){
            if (collision.gameObject.CompareTag("PlayerWeapon")){
                // 接触した弾を削除する
                Destroy(collision.gameObject);
                
                int value = collision.gameObject.GetComponent<FireBullet>().attackPower;
                Damage(value);
            }
        }
    }

	public void SetCurrentHp(int hp){
		this.currentHp = currentHp;
	}

	public int GetCurrentHp(){
		return currentHp;
	}

    public int GetMaxHp() {
        return maxHp;
    }

    public void UpdateHPValue(){
        hpSlider.value = (float)GetCurrentHp() / (float)GetMaxHp();
    }
}
