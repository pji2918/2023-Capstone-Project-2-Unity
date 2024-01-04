using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TextTyping;
using TMPro;
using DG.Tweening;

public class BattleShip : MonoBehaviour
{
    public static BattleShip instance;
    public GameObject[] walls;
    public GameObject Ship;
    public GameObject Turret;
    public TextMeshProUGUI Gamerule;
    public bool lightOpen;
    public GameObject Light;
    public float Times = 100;
    public Typing textTyping = new Typing();
    public Image fadeImage;

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
        fadeImage.DOFade(0, 1.5f).OnComplete(() =>
        {
            fadeImage.gameObject.SetActive(false);
        });


        AudioSource audioSource = Gamerule.transform.parent.GetComponent<AudioSource>();

        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("포탈을 타긴했는데.. 저앞에 있는 괴물은 뭐야", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("몬스터가 이상한 스킬들을 쓰고있어!!", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("저건... 적 본진의 에너지를 채워주는 스킬이잖아!??", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("저 뒤에 있는 블럭의 중앙이 에너지 저장소인거같아", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("최대한 빨리 처리해야겠어!", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("뒤에 있는 저장소를 부셔 적의 에너지를 차단시키자!", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        Gamerule.text = "";
        Turret.SetActive(true);
        Gamerule.text = "";
        lightOpen = false;
    }
}
