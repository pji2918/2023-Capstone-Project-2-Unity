using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextTyping;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EndText : MonoBehaviour
{
    public TextMeshProUGUI Gamerule;
    private Typing typing = new Typing();
    [SerializeField] private UnityEngine.UI.Image fadeImage;

    void Start()
    {
        StartCoroutine(EndTexts());
    }

    IEnumerator EndTexts()
    {
        AudioSource audioSource = Gamerule.transform.parent.GetComponent<AudioSource>();
        yield return new WaitForSeconds(3);
        StartCoroutine(typing.TypeText("죽었나? 드디어 300년의 복수를 끝낼 수 있다.", Gamerule, audioSource));
        yield return new WaitForSeconds(6);
        StartCoroutine(typing.TypeText("정복을 당했을때 남은 단 하나의 군함과 우주선으로 승리를 쟁취했다!", Gamerule, audioSource));
        yield return new WaitForSeconds(6);
        StartCoroutine(typing.TypeText("나는 앞으로 흩어진 우리 코스모넛 행성의 사람들을 찾아 다녀야지.", Gamerule, audioSource));
        yield return new WaitForSeconds(6);
        StartCoroutine(typing.TypeText("이젠 다른 행성과 사람들을 찾으러 출발할 것이다.", Gamerule, audioSource));
        yield return new WaitForSeconds(6);
        Gamerule.text = "";
        if (fadeImage == null)
        {
            fadeImage = FindAnyObjectByType<BossAttack>().fadeImage;
        }
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene("EndAnimeScene");
        });
    }
}
