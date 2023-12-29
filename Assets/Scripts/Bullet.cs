using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 100f;

    Vector3 dir;

    private void Start()
    {
        dir = Vector3.forward * speed * Time.deltaTime;

        Destroy(this.gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(dir);
    }

    private void OnTriggerEnter(Collider other)
    {
        //todo : damaged
    }
}
