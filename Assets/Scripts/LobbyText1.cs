using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextTyping;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LobbyText1 : MonoBehaviour
{
    public TextMeshProUGUI Gamerule;
    private Typing typing = new Typing();
    [SerializeField] private UnityEngine.UI.Image fadeImage;
    void Start()
    {
        StartCoroutine(Lobbytexts());
    }

    IEnumerator Lobbytexts()
    {
        AudioSource audioSource = Gamerule.transform.parent.GetComponent<AudioSource>();
        yield return new WaitForSeconds(3);
        StartCoroutine(typing.TypeText("지금으로부터 300년전 가재왕이 우리 기지인 코스모넛 행성을 정복하였다", Gamerule, audioSource));
        yield return new WaitForSeconds(6);
        StartCoroutine(typing.TypeText("정복을 당하면서 많은 군함을 뺏기고 나에겐 단 하나의 군함과 우주선만이 남았다..", Gamerule, audioSource));
        yield return new WaitForSeconds(6);
        StartCoroutine(typing.TypeText("나는 복수를 위해 우주선을 개발해왔고 드디어 오늘 적군의 기지를 공격하려한다.", Gamerule, audioSource));
        yield return new WaitForSeconds(6);
        StartCoroutine(typing.TypeText("이제 적진으로 출발하겠다 오바", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        Gamerule.text = "";
        if (fadeImage == null)
        {
            fadeImage = FindAnyObjectByType<BossAttack>().fadeImage;
        }
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene("StartAnimeScene");
        });
    }
}
