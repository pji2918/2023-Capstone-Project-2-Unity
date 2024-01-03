using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TextTyping;
using TMPro;

public class BattleShip : MonoBehaviour
{
    public static BattleShip instance;
    public GameObject[] walls;
    public GameObject Ship;

    public GameObject Turret;

    public TextMeshProUGUI Gamerule;
    public float Times = 100;

    public Typing textTyping = new Typing();
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        StartCoroutine(Texts());


    }
    void Update()
    {
        Times = Times - Time.deltaTime;

    }
    IEnumerator Texts()
    {
        AudioSource audioSource = Gamerule.transform.parent.GetComponent<AudioSource>();

        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("적의 기지앞에 역습했다", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("이런 앞이 막혀있잖아!", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("포탈을 잘못타고왔나...?", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("빨리 우주선을 찾아서 뚫어야해!!", Gamerule, audioSource));
        yield return new WaitForSeconds(3);
        StartCoroutine(textTyping.TypeText("우주선을 찾아 이곳을 공격하세요!!!", Gamerule, audioSource));
        yield return new WaitForSeconds(1);
        Gamerule.text = "";



        Turret.SetActive(true);
    }

    // Update is called once per frame
}
