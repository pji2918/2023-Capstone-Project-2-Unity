using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextTyping;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    Typing typing = new Typing();
    public TextMeshProUGUI BossText;

    public GameObject[] Bosss;

    public GameObject[] reactor;

    public GameObject Portal;

    public GameObject Enemybase;

    public Image fadeImage;

    void Start()
    {
        StartCoroutine(BossCreate());
    }
    IEnumerator BossCreate()
    {
        fadeImage.DOFade(0, 1.5f).OnComplete(() =>
        {
            fadeImage.gameObject.SetActive(false);
        });
        AudioSource audioSource = BossText.transform.parent.GetComponent<AudioSource>();

        yield return new WaitForSeconds(2f);
        StartCoroutine(typing.TypeText("어라..? 왜 아무것도 없는거야?", BossText, audioSource));
        yield return new WaitForSeconds(4f);
        StartCoroutine(typing.TypeText("전부 해치운건가? 그럼 상대 본진을 공격하러 가자!", BossText, audioSource));
        foreach (GameObject boss in Bosss)
        {
            boss.SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(typing.TypeText("뭐야!!!!! 함정이였다니..", BossText, audioSource));
        yield return new WaitForSeconds(1f);
        BossText.text = "모든 적을 해치우고 본진을 공격하세요!!";
        yield return new WaitForSeconds(3f);
        BossText.text = "";

    }

    // Update is called once per frame
    void Update()
    {

        if (!reactor[0].activeSelf)
        {
            Portal.SetActive(true);
        }

    }
}
