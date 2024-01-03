using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;

public class SkillAttack : MonoBehaviour
{
    public DamageReceiver damageReceiver;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (time <= 0 && (other.CompareTag("Skill1") || other.CompareTag("Skill2") || other.CompareTag("Skill3") || other.CompareTag("Skill2")))
        {
            Debug.Log("SkillAttack");
            damageReceiver.Damage(70);
            time = 0.5f;
        }
    }
}
