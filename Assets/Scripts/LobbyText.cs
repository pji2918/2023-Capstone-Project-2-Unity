using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;
using System.Collections;
using TMPro;

public class LobbyText : MonoBehaviour
{

}

namespace TextTyping
{
    public class Typing
    {
        /// <summary>
        /// 텍스트를 순차적으로 출력합니다.
        /// </summary>
        /// <param name="text">순차적으로 출력할 텍스트</param>
        /// <param name="txtUI">출력 대상을 Text 형식으로 입력</param>
        /// <returns>없음. 코루틴의 WaitForSeconds만을 반환합니다.</returns>
        public IEnumerator TypeText(string text, TMP_Text txtUI, AudioSource audioSource)
        {
            int length = text.GetTypingLength();

            for (int i = 0; i <= length; i++)
            {
                audioSource.Play();
                txtUI.text = text.Typing(i);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}