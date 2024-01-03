using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public float fadeDuration = 1.0f; // 페이드 인/아웃 지속 시간

    private Image fadeImage; // 페이드에 사용될 UI 이미지

    void Start()
    {
        StartFadeIn();
        // UI 이미지 가져오기 (이미지가 아니라 다른 요소를 사용할 수도 있음)
        fadeImage = GetComponent<Image>();

        // 시작 시 투명도를 0으로 설정하여 페이드인 효과를 시작합니다.
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
    }


    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    // 페이드아웃 효과를 시작하는 함수
    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    // 페이드인 코루틴
    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 페이드인 완료 후 필요한 작업 수행
    }

    // 페이드아웃 코루틴
    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 페이드아웃 완료 후 필요한 작업 수행
    }
}

