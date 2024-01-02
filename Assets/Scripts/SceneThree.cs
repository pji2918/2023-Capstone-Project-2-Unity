using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneThree : MonoBehaviour
{
    public Text Gamerule;
    public GameObject[] settings;
    bool setting;

    public GameObject Wave;

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
        yield return new WaitForSeconds(3);
        Gamerule.text = "여긴어디지..?";
        yield return new WaitForSeconds(3);
        Gamerule.text = "벌써 밤이라니..";
        yield return new WaitForSeconds(3);
        Gamerule.text = "레이더엔 아무것도 안찍혀";
        yield return new WaitForSeconds(3);
        Gamerule.text = "이곳의 위치를 알아봐야할것같아";
        yield return new WaitForSeconds(3);
        Gamerule.text = "레이더에 탐지되는것들로 이곳의 위치를 알아내세요!";
    }

    IEnumerator bull()
    {
        yield return new WaitForSeconds(3);
        Gamerule.text = "이건 대체 뭐야?";
        yield return new WaitForSeconds(3);
        Gamerule.text = "운석들에 끼여서 못가고있었던것같네";
        yield return new WaitForSeconds(3);
        Gamerule.text = "지원병들이 오는소리가 들려...!";
        yield return new WaitForSeconds(3);
        Gamerule.text = "적을 모두 처치하고 포탈로 탈출하자...!";
        Wave.SetActive(true);
        yield return new WaitForSeconds(3);
        Gamerule.text = "";
        setting = false;
        setting2 = true;
    }
}
