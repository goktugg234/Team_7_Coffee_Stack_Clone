using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public Joystick variableJoystick;
    public float moveSpeed;
    float forwardSpeed = 0.8f;


    public Vector3 direction;
    Camera cam;
    public Vector2 xLimit;

    //[HideInInspector]
    public bool isGoing = false, isFinished = false;

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
            direction.x = Mathf.Clamp(direction.x, xLimit.x, xLimit.y);     //x limitasyonu, i�e yaram�yor

            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        if(isFinished){
            transform.position= new Vector3(0, transform.position.y, transform.position.z);
            
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
    //    //TRANSFORM �LE HAREKET---UPDATE ��ERS�NDE �ALI�TIRILAB�L�R
    //    //transform.rotation = Quaternion.LookRotation(direction);
    //    //transform.Translate(direction.x, 0, moveSpeed );     //karakterin �n� y�n�nde ilerletilecek

    //    //HER Y�NE HAREKET
    //    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
    //    //rb.velocity = transform.forward * moveSpeed;        //bazen triggerlar�n i�inden ge�iyor. rb ile hareket ettirilirse ge�meyebilir. rb ile harekette time.deltatime ile �arp�lmaz

    //    //RB �LE HAREKET
    //    rb.velocity = direction * moveSpeed;
    //}
}
