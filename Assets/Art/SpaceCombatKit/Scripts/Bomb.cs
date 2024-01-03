using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
    public int count = 0;

    public float countdown = 30f;

    public Text bombText;

    public bool collider = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && collider == true && count == 0)
        {
            count++;
            Debug.Log('1');
            bomb = GameObject.Instantiate(bomb, transform.position, quaternion.identity);
        }
        if (count == 1)
        {
            countdown -= Time.deltaTime;
            bombText.text = $"{countdown:N1}";
        }
        if (countdown < 0)
        {
            bombText.text = "타임 아웃";
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BombPosition"))
        {


            collider = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BombPosition"))
        {
            collider = false;
        }
    }

    public void bomb2()
    {

    }
}
