using System.Collections;
using Unity.Mathematics;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animator animator;

    public Transform player;

    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;

    public Transform zapu;

    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("RandomAttack", 0f, 4f);
        StartCoroutine(Rull());
    }

    void Update()
    {
        zapu.transform.LookAt(player);
    }


    IEnumerator Rull()
    {
        yield return new WaitForSeconds(3f);
        PortalController portalController = FindObjectOfType<PortalController>();
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
        int attackIndex = UnityEngine.Random.Range(0, 4);

        animator.SetBool("Attack1", false);
        animator.SetBool("Attack2", false);
        animator.SetBool("Attack3", false);
        animator.SetBool("Attack4", false);

        Debug.Log(attackIndex);

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

    void LaunchSkill(GameObject skillPrefab)
    {
        if (player != null)
        {
            Vector3 direction = (player.position - zapu.position).normalized;
            GameObject skillInstance = Instantiate(skillPrefab, zapu.position, zapu.rotation);
            // Adjust the speed or force of the skill based on your game logic
            float skillSpeed = 5.0f; // Adjust this value as needed
            skillInstance.GetComponent<Rigidbody>().velocity = direction * skillSpeed;
        }
        else
        {
            Debug.LogWarning("Player not found.");
        }
    }

    void OnDestroy()
    {
        CancelInvoke("RandomAttack");
    }

}
