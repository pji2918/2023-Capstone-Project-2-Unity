using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PortalController : MonoBehaviour
{
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
            SceneManager.LoadScene("GameScene2");

        }
        if (other.CompareTag("portal2"))
        {
            SceneManager.LoadScene("GameScene3");

        }
        if (other.CompareTag("portal5"))
        {
            SceneManager.LoadScene("Boss");

        }

    }

}

