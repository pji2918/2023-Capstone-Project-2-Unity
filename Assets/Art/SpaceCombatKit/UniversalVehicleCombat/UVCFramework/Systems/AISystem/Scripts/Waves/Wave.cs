using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public GameObject Portal2;
    public TextMeshProUGUI Portal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WaveDataManager.instance.waveCount == 1)
        {
            Portal2.SetActive(true);
            Portal.text = "포탈을 찾아이동하세요..!";
        }

    }
}
