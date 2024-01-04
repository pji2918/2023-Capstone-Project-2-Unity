using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BossAttack2 : MonoBehaviour
{
    private Animator animator;

    public Transform player;

    public GameObject skill1;
    public GameObject skill2;
    public GameObject Portal;

    public GameObject[] block;
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


        if (!block[0].activeSelf)
        {
            Portal.SetActive(true);
            animator.SetBool("Dies", true);

        }

    }


    IEnumerator Rull()
    {
        yield return new WaitForSeconds(1f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        int attackIndex = UnityEngine.Random.Range(0, 2);

        animator.SetBool("Skill1", false);
        animator.SetBool("SKill2", false);


        Debug.Log(attackIndex);

        // Set the selected attack using switch statement
        switch (attackIndex)
        {
            case 0:
                animator.SetTrigger("Skill1");
                LaunchSkill(skill1);
                break;
            case 1:
                animator.SetTrigger("Skill2");
                LaunchSkill(skill2);
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
            float skillSpeed = 4.0f; // Adjust this value as needed
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
