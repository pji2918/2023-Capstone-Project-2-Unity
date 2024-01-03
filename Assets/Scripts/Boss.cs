using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public Text BossText;

    public GameObject[] Bosss;

    public GameObject[] reactor;

    public GameObject Portal;

    public GameObject Enemybase;

    void Start()
    {
        StartCoroutine(BossCreate());
    }
    IEnumerator BossCreate()
    {
        yield return new WaitForSeconds(2f);
        BossText.text = "어라..? 왜 아무것도 없는거야";
        yield return new WaitForSeconds(4f);
        BossText.text = "상대 본진을 공격할 일만남았어!";
        foreach (GameObject boss in Bosss)
        {
            boss.SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        BossText.text = "뭐야!!!!! 함정에 빠졌다";
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
