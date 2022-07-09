using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //フラグ
    private bool flag = true;

    public BreakDown breakdown;
    public GameClearAnimation GameClearAnimation;
    public TanbaCutInTest TanbaCutInTest;

    [SerializeField]
    private ToGameOver _gameOver;

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

        // Debug.Log(currentHp);

        // HP表示用UIのアップデート
        UpdateHPValue();
        
         if(currentHp <= 0 && flag)
         {
             //Dead();
             if (this.gameObject.CompareTag("PlayerTower"))
             {
                flag = false;
                TanbaCutInTest.Cutin();

                // _gameOver.ChangeScene();
             }
             else if(this.gameObject.CompareTag("EnemyTower"))
             {
                flag = false;
                Debug.Log("OK");
                this.gameObject.GetComponent<Detonator>().Explode();
                GameClearAnimation.TyoKaiSyoBun();
                StartCoroutine(WaitTyokai());
                // TanbaCutInTest.Cutin();
                breakdown.Explosion();
                //Invoke(nameof(GameClearAnimation.ChangeGameClearScene), 2.0f);
            }
        }
    }

    private IEnumerator WaitTyokai()
    {
        yield return new WaitForSeconds(5);
    }

    //武器に触れたらダメージ
    protected void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.CompareTag("PlayerTower")){
            if (collision.gameObject.CompareTag("EnemyWeapon")){
                int value = collision.gameObject.GetComponent<HommingBullet>().attackPower;
                
                // 接触した弾を削除する
                Destroy(collision.gameObject);
                
                Damage(value);
            }
        }
        else if(this.gameObject.CompareTag("EnemyTower")){
            if (collision.gameObject.CompareTag("PlayerWeapon")){
                int value = collision.gameObject.GetComponent<HommingBullet>().attackPower;
                
                // 接触した弾を削除する
                Destroy(collision.gameObject);
                
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
