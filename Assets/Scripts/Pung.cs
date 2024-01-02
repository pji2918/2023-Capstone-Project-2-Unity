using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pung : MonoBehaviour
{
    public GameObject[] reactor;

    public GameObject portal;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(!reactor[0].activeSelf);
        if (!reactor[0].activeSelf)
        {
            portal.SetActive(true);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("portal3"))
        {
            SceneManager.LoadScene("End");
        }
    }
}
