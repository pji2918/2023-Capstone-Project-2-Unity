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
    float yRotate;
    float yRotateMove;
    Vector3 dir;

    public enum WeaponMode
    {
        none,
        bullet,
        laser,
    }

    public WeaponMode curWeapon = WeaponMode.bullet;
    public GameObject bulletPrefab;
    public Transform leftFirePos;
    public Transform rightFirePos;


    private void Start()
    {
        //컴포넌트 설정
        rd = GetComponent<Rigidbody>();

        //초기 스텟 할당
        shieldAmount = 50;
        maxHp = 100;
        hp = maxHp;
        speed = 1000;
        rotSpeed = 20;
        camSpeed = 200;
    }

    private void Update()
    {
        #region player Movement
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        dir = transform.TransformDirection(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime);
        rd.AddForce(dir);

        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * camSpeed;
        yRotateMove = -Input.GetAxis("Mouse X") * Time.deltaTime * camSpeed;
        //xRotate = transform.eulerAngles.x + xRotateMove; 
        xRotate = xRotate + xRotateMove;
        yRotate = yRotate + yRotateMove;

        //transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        Quaternion quat = Quaternion.Euler(new Vector3(xRotate, yRotate, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime /* x speed */);

        if(Input.GetKey(KeyCode.Space))
        {
            rd.AddForce(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.C))
        {
            rd.AddForce(Vector3.down * speed * Time.deltaTime);
        }
        #endregion

        if(Input.GetMouseButtonDown(0))
        {
            switch(curWeapon)
            {
                case WeaponMode.bullet:
                    BulletShoot();
                    break;

                case WeaponMode.laser:
                    break;
            }
        }
    }


    void BulletShoot()
    {
        GameObject leftBullet = Instantiate(bulletPrefab);
        leftBullet.transform.position = leftFirePos.position;
        leftBullet.transform.rotation = gameObject.transform.rotation;

        GameObject rightBullet = Instantiate(bulletPrefab);
        rightBullet.transform.position = rightFirePos.position;
        rightBullet.transform.rotation = gameObject.transform.rotation;

    }

    //IEnumerator Laser()
    //{
    //
    //}
}
