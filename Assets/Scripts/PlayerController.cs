using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //컴포넌트
    Rigidbody rd;

    //변수 지정
    float shieldAmount = 50;
    float hp = 100;
    float maxHp = 100;
    float speed = 1000;
    float rotSpeed = 20;
    float camSpeed = 200;

    float h;
    float v;
    float xRotate;
    float xRotateMove;
    Vector3 dir;
    

    private void Start()
    {
        //컴포넌트 설정
        rd = GetComponent<Rigidbody>();

        //초기 스텟 할당
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        dir = transform.TransformDirection(Vector3.forward) * v * speed * Time.deltaTime;
        rd.AddForce(dir);
        transform.Rotate(0.0f, h * rotSpeed * Time.deltaTime, 0.0f);

        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * camSpeed;
        //xRotate = transform.eulerAngles.x + xRotateMove; 
        xRotate = xRotate + xRotateMove;

        //transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        Quaternion quat = Quaternion.Euler(new Vector3(xRotate, 0, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime /* x speed */);
    }
}
