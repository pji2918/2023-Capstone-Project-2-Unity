using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class BossAttack : MonoBehaviour
{
    private Animator animator;

    public Transform player;

    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;

    public Text Bosstext;
    public Text PlayerText;

    public GameObject[] Reporter;

    public Transform zapu;

    public GameObject Portal;

    bool action = false;
    bool rull2Running = false; // 추가된 변수

    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("RandomAttack", 0f, 4f);
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
        rull2Running = true; // 코루틴이 시작되었음을 표시
        yield return new WaitForSeconds(3f);
        PlayerText.text = "보스를 처치하는데 성공했어!";
        yield return new WaitForSeconds(3f);
        PlayerText.text = "빠르게 포탈로 이동해보자";
        yield return new WaitForSeconds(3f);
        PlayerText.text = "";
        action = false;
        rull2Running = false; // 코루틴이 종료되었음을 표시
    }

    IEnumerator Rull()
    {
        yield return new WaitForSeconds(1f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        yield return new WaitForSeconds(3f);
        PortalController portalController = FindObjectOfType<PortalController>();
        Bosstext.text = "감히 우리본진을 터트려??";
        yield return new WaitForSeconds(3f);
        Bosstext.text = "죽여버리겠다!!";
        yield return new WaitForSeconds(1f);
        Bosstext.text = "";
        yield return new WaitForSeconds(5f);
        PlayerText.text = "적의 보스는 보호막을 뚫는스킬들이야";
        yield return new WaitForSeconds(3f);
        PlayerText.text = "최대한 스킬을 피한후 보스가 지키고있는 라이트닝을 부셔야해!";

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
            int attackIndex = UnityEngine.Random.Range(0, 4);

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
