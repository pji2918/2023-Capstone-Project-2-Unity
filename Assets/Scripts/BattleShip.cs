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
        StartCoroutine(textTyping.TypeText("저 괴물이 이상한 빛을 뿜어내고 있어!!", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("저 빛이...! 적 본진의 에너지를 채워주고 있잖아!??", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("저 뒤에 있는 블럭의 중앙이 에너지 저장소인거 같아", Gamerule, audioSource));
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
