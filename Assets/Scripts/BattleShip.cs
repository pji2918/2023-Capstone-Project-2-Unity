using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BattleShip : MonoBehaviour
{
    public static BattleShip instance;
    public GameObject[] walls;
    public GameObject Ship;

    public GameObject Turret;

    public Text Gamerule;
    public float Times = 100;
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
        yield return new WaitForSeconds(3);
        Gamerule.text = "적의 기지앞에 역습했다";
        yield return new WaitForSeconds(3);
        Gamerule.text = "이런 앞이 막혀있잖아!";
        yield return new WaitForSeconds(3);
        Gamerule.text = "포탈을 잘못타고왔나...?";
        yield return new WaitForSeconds(3);
        Gamerule.text = "빨리 우주선을 찾아서 뚫어야해!!";
        yield return new WaitForSeconds(3);
        Gamerule.text = "우주선을 찾아 이곳을 공격하세요!!!";
        yield return new WaitForSeconds(1);
        Gamerule.text = "";



        Turret.SetActive(true);
    }

    // Update is called once per frame

}
