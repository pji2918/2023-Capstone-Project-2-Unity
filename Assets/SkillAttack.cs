using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skill1"))
        {

        }
        else if (other.CompareTag("Skill2"))
        {

        }
        else if (other.CompareTag("Skill3"))
        {

        }
        else if (other.CompareTag("Skill4"))
        {

        }
    }
}
