using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BattleShip : MonoBehaviour
{
    public static BattleShip instance;
    public GameObject[] walls;
    public GameObject Ship;

    public GameObject Turret;

    public bool lightOpen;
    public GameObject Light;



    public Text Gamerule;



    public float Times = 100;
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }

        StartCoroutine(Texts());
    }

    void Update()
    {
        Times = Times - Time.deltaTime;

    }
    IEnumerator Texts()
    {
        yield return new WaitForSeconds(3);
        Gamerule.text = "포탈을 타긴했는데.. 저앞에 있는 괴물은 뭐야";
        yield return new WaitForSeconds(3);
        Gamerule.text = "몬스터가 이상한 스킬들을 쓰고있어!!";
        yield return new WaitForSeconds(3);
        Gamerule.text = "저건... 적 본진의 에너지를 채워주는 스킬이잖아!??";
        yield return new WaitForSeconds(3);
        Gamerule.text = "저 뒤에 있는 블럭의 중앙이 에너지 저장소인거같아";
        yield return new WaitForSeconds(3);
        Gamerule.text = "최대한 빨리 처리해야겠어!";
        yield return new WaitForSeconds(3);
        Gamerule.text = "뒤에 있는 저장소를 부셔 적의 에너지를 차단시키자!";
        yield return new WaitForSeconds(3);
        Gamerule.text = "";
        Turret.SetActive(true);
        Gamerule.text = "";
        lightOpen = false;

    }
}
