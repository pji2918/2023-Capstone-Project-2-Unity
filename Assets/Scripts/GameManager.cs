using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameRule;
    public Image fadeImage;
    void Start()
    {
        StartCoroutine(rule());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator rule()
    {
        fadeImage.DOFade(0, 1.5f).OnComplete(() =>
        {
            fadeImage.gameObject.SetActive(false);
        });
        yield return new WaitForSeconds(1);
        gameRule.text = "잠시후 게임이 시작됩니다";
        yield return new WaitForSeconds(1);
        gameRule.text = "5";
        yield return new WaitForSeconds(1);
        gameRule.text = "4";
        yield return new WaitForSeconds(1);
        gameRule.text = "3";
        yield return new WaitForSeconds(1);
        gameRule.text = "2";
        yield return new WaitForSeconds(1);
        gameRule.text = "1";
        yield return new WaitForSeconds(1);
        gameRule.text = "";
        yield return new WaitForSeconds(1);
        gameRule.text = "모든 적을 처치하세요!";
        yield return new WaitForSeconds(3);
        gameRule.text = "";


    }
}
