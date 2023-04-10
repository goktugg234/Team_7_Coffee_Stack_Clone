using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public Joystick variableJoystick;
    public int moveSpeed;
    float forwardSpeed = 0.8f;


    Vector3 direction;
    //Rigidbody rb;
    Camera cam;
    public Vector2 xLimit;

    //[HideInInspector]
    public bool isGoing = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        //float inputZ = variableJoystick.Vertical;
        //direction = new Vector3(inputX, 0, forwardSpeed);
        MovementUpdate();
    }

    public void MovementUpdate()
    {
        if (isGoing)
        {
            float inputX = variableJoystick.Horizontal;
            direction = cam.transform.TransformVector(inputX, 0, forwardSpeed);
            //direction = cam.transform.TransformVector(forwardSpeed, 0, inputX);
            direction.y = 0;
            direction.x = Mathf.Clamp(direction.x, xLimit.x, xLimit.y);     //x limitasyonu, iþe yaramýyor

            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }


    //void FixedUpdate()
    //{
    //    //if (isGoing)
    //    //{
    //    //    MovementFixedUpdate();
    //    //}
    //}

    //void MovementFixedUpdate()
    //{
    //    //TRANSFORM ÝLE HAREKET---UPDATE ÝÇERSÝNDE ÇALIÞTIRILABÝLÝR
    //    //transform.rotation = Quaternion.LookRotation(direction);
    //    //transform.Translate(direction.x, 0, moveSpeed );     //karakterin önü yönünde ilerletilecek

    //    //HER YÖNE HAREKET
    //    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
    //    //rb.velocity = transform.forward * moveSpeed;        //bazen triggerlarýn içinden geçiyor. rb ile hareket ettirilirse geçmeyebilir. rb ile harekette time.deltatime ile çarpýlmaz

    //    //RB ÝLE HAREKET
    //    rb.velocity = direction * moveSpeed;
    //}
}
