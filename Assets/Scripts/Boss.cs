using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextTyping;

public class Boss : MonoBehaviour
{
    Typing typing = new Typing();
    public TextMeshProUGUI BossText;

    public GameObject[] Bosss;

    public GameObject[] reactor;

    public GameObject Portal;

    void Start()
    {
        StartCoroutine(BossCreate());
    }
    IEnumerator BossCreate()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(typing.TypeText("어라..? 왜 아무것도 없는거야", BossText));
        yield return new WaitForSeconds(4f);
        StartCoroutine(typing.TypeText("상대 본진을 공격할 일만남았어!", BossText));
        foreach (GameObject boss in Bosss)
        {
            boss.SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(typing.TypeText("뭐야!!!!! 함정에 빠졌다", BossText));
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
