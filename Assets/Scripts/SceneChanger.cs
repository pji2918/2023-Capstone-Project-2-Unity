using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public string sceneName;
    public Image fadeImage;

    void Start()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}
