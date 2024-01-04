using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextTyping;
using DG.Tweening;


public class BossAttack : MonoBehaviour
{
    private Animator animator;

    public Transform player;

    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;

    public TextMeshProUGUI Bosstext;
    public TextMeshProUGUI PlayerText;

    public GameObject[] Reporter;

    public Transform zapu;

    public GameObject Portal;
    Typing typing = new Typing();
    public Image fadeImage;
    bool action = false;
    bool rull2Running = false; // 추가된 변수

    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("RandomAttack", 0f, 5f);
        StartCoroutine(Rull());
    }

    void Update()
    {
        zapu.transform.LookAt(player);
        if (!Reporter[0].activeSelf)
        {
            action = true;
            if (!rull2Running) // 이전에 실행 중인 경우에는 다시 실행하지 않음
            {
                StartCoroutine(Rull2());
            }

            StopSkillAnimations();
            animator.SetTrigger("Die");
            Portal.SetActive(true);
        }
    }

    void StopSkillAnimations()
    {
        animator.SetBool("Attack1", false);
        animator.SetBool("Attack2", false);
        animator.SetBool("Attack3", false);
        animator.SetBool("Attack4", false);
    }

    IEnumerator Rull2()
    {
        AudioSource playerAudioSource = PlayerText.transform.parent.GetComponent<AudioSource>();
        rull2Running = true; // 코루틴이 시작되었음을 표시
        yield return new WaitForSeconds(3f);
        StartCoroutine(typing.TypeText("보스를 처치하는데 성공했어!", PlayerText, playerAudioSource));
        yield return new WaitForSeconds(3f);
        StartCoroutine(typing.TypeText("빠르게 포탈로 이동해보자", PlayerText, playerAudioSource));
        yield return new WaitForSeconds(3f);
        PlayerText.text = "";
        action = false;
        rull2Running = false; // 코루틴이 종료되었음을 표시
    }

    IEnumerator Rull()
    {
        fadeImage.DOFade(0, 1.5f).OnComplete(() =>
        {
            fadeImage.gameObject.SetActive(false);
        });
        AudioSource playerAudioSource = PlayerText.transform.parent.GetComponent<AudioSource>();
        AudioSource bossAudioSource = Bosstext.transform.parent.GetComponent<AudioSource>();
        yield return new WaitForSeconds(1f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        yield return new WaitForSeconds(3f);
        PortalController portalController = FindObjectOfType<PortalController>();
        StartCoroutine(typing.TypeText("감히 우리 군함을 공격하다니!", Bosstext, bossAudioSource));
        yield return new WaitForSeconds(3f);
        StartCoroutine(typing.TypeText("죽어라!!", Bosstext, bossAudioSource));
        yield return new WaitForSeconds(1f);
        Bosstext.text = "";
        yield return new WaitForSeconds(5f);
        StartCoroutine(typing.TypeText("저 빛은 여태까지와는 좀 다른 것 같아. 보호막을 기대할 수는 없을 것 같네..", PlayerText, playerAudioSource));
        yield return new WaitForSeconds(3f);
        StartCoroutine(typing.TypeText("저건 뭐지? 저렇게까지 지키고 있다니 중요한 건가..?", PlayerText, playerAudioSource));
        yield return new WaitForSeconds(3f);
        StartCoroutine(typing.TypeText("공격을 최대한 피해가머 저기 가재왕이 지키고있는 것을 부셔야겠어!", PlayerText, playerAudioSource));

        if (portalController != null)
        {
            player = portalController.transform;
        }
        else
        {
            Debug.LogWarning("PortalController not found.");
        }
    }

    void RandomAttack()
    {
        if (action == false)
        {
            int attackIndex = Random.Range(0, 4);

            StopSkillAnimations();

            // Set the selected attack using switch statement
            switch (attackIndex)
            {
                case 0:
                    animator.SetBool("Attack1", true);
                    LaunchSkill(skill1);
                    break;
                case 1:
                    animator.SetBool("Attack2", true);
                    LaunchSkill(skill2);
                    break;
                case 2:
                    animator.SetBool("Attack3", true);
                    LaunchSkill(skill3);
                    break;
                case 3:
                    animator.SetBool("Attack4", true);
                    LaunchSkill(skill4);
                    break;
            }
        }
    }

    void LaunchSkill(GameObject skillPrefab)
    {
        if (action == false)
        {
            Debug.Log("LaunchSkill called");

            if (player != null)
            {
                Vector3 direction = (player.position - zapu.position).normalized;
                GameObject skillInstance = Instantiate(skillPrefab, zapu.position, zapu.rotation);
                float skillSpeed = 5.0f;
                skillInstance.GetComponent<Rigidbody>().velocity = direction * skillSpeed;
            }
            else
            {
                Debug.LogWarning("Player not found.");
            }
        }
    }

    void OnDestroy()
    {
        CancelInvoke("RandomAttack");
    }
}
