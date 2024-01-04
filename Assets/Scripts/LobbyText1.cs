using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyText1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lobbytexts());
    }

    IEnumerator Lobbytexts()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("지금으로부터 300년전 가재왕이 우리 기지인 코스모넛 행성을 정복하였다");
        Debug.Log("정복을 당하면서 많은 군함을 뺏기고 나에겐 군함과 우주선이 단 하나씩만 남았다..");
        Debug.Log("나는 복수를 위해 우주선을 개발해왔고 드디어 오늘 적군의 기지를 공격하려한다.");
        Debug.Log("이제 적진으로 출발하겠다 오바");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
