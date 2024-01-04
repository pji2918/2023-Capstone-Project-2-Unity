using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("portal"))
        {
            if (fadeImage == null)
            {
                fadeImage = FindAnyObjectByType<GameManager>().fadeImage;
            }
            fadeImage.gameObject.SetActive(true);
            fadeImage.DOFade(1, 1.5f).OnComplete(() =>
            {
                SceneManager.LoadScene("GameScene2");
            });
        }
        if (other.CompareTag("portal2"))
        {
            if (fadeImage == null)
            {
                fadeImage = FindAnyObjectByType<BattleShip>().fadeImage;
            }
            fadeImage.gameObject.SetActive(true);
            fadeImage.DOFade(1, 1.5f).OnComplete(() =>
            {
                SceneManager.LoadScene("GameScene2EndAnimeScene");
            });
        }
        if (other.CompareTag("portal5"))
        {
            if (fadeImage == null)
            {
                fadeImage = FindAnyObjectByType<SceneThree>().fadeImage;
            }
            fadeImage.gameObject.SetActive(true);
            fadeImage.DOFade(1, 1.5f).OnComplete(() =>
            {
                SceneManager.LoadScene("Boss");
            });
        }
        if (other.CompareTag("portalend"))
        {
            if (fadeImage == null)
            {
                fadeImage = FindAnyObjectByType<BossAttack>().fadeImage;
            }
            fadeImage.gameObject.SetActive(true);
            fadeImage.DOFade(1, 1.5f).OnComplete(() =>
            {
                SceneManager.LoadScene("BossDieAnimeScene");
            });
        }
    }

}

