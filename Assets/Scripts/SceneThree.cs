using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TextTyping;
using TMPro;
using DG.Tweening;

public class SceneThree : MonoBehaviour
{
    public TextMeshProUGUI Gamerule;
    public GameObject[] settings;
    bool setting;

    private Typing typing = new Typing();

    public GameObject Wave;
    public Image fadeImage;
    bool setting2;
    void Start()
    {
        StartCoroutine(Texts());
    }

    // Update is called once per frame
    void Update()
    {
        if (!settings[0].activeSelf && setting2 == false)
        {
            if (!setting)  // Check if setting is not already true
            {
                setting = true;
                StartCoroutine(bull());
            }
        }
    }

    IEnumerator Texts()
    {
        fadeImage.DOFade(0, 1.5f).OnComplete(() =>
        {
            fadeImage.gameObject.SetActive(false);
        });
        AudioSource audioSource = Gamerule.transform.parent.GetComponent<AudioSource>();

        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("여긴 어디지..?", Gamerule, audioSource));
        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("벌써 밤이네..", Gamerule, audioSource));
        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("레이더엔 아무것도 안보여.", Gamerule, audioSource));
        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("이곳의 위치를 알아내야겠어", Gamerule, audioSource));
        yield return new WaitForSeconds(5);
        Gamerule.text = "레이더에 탐지되는것들로 이곳의 위치를 알아내세요!";
    }

    IEnumerator bull()
    {
        AudioSource audioSource = Gamerule.transform.parent.GetComponent<AudioSource>();

        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("이건 대체 뭐야?", Gamerule, audioSource));
        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("저 군함은 운석들 사이에서 움직이지 못하고 있었던 것 같네.", Gamerule, audioSource));
        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("레이더에 적 우주선이 감지됐어. 지원병들인가...?", Gamerule, audioSource));
        yield return new WaitForSeconds(5);
        StartCoroutine(typing.TypeText("적을 모두 처치하고 포탈로 탈출하자!", Gamerule, audioSource));
        Wave.SetActive(true);
        yield return new WaitForSeconds(3);
        Gamerule.text = "";
        setting = false;
        setting2 = true;
    }


}
