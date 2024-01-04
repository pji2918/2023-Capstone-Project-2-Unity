using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TItleManager : MonoBehaviour
{
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Run()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, 1.5f).onComplete = () =>
        {
            SceneManager.LoadScene("Lobby");
        };
    }

    public void Quit()
    {
        Application.Quit();
    }
}
