﻿using UnityEngine;
using System.Collections;


namespace YJ.Zombie.Cha
{
    public class ChaMove : MonoBehaviour
    {
        private Animator anim;
        private float _speed = 5.0f;
        private Rigidbody _rigidbody;
        private float _rotationSpeed = 1000f;
        void Awake()
        {
            anim = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("Run", true);
                transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * _speed);
            }
            else
            {
                anim.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("RunLeft", true);
                transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * _speed);
            }
            else
            {
                anim.SetBool("RunLeft", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("RunRight", true);
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * _speed);
            }
            else
            {
                anim.SetBool("RunRight", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("RunBack", true);
                transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * _speed);
            }
            else
            {
                anim.SetBool("RunBack", false);
            }

           

            Rotate();
        }

        private void Rotate()
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

            Vector3 direction = mouseWorldPosition - transform.position;
            direction.y = 0f; // y 축 회전을 제한하기 위해 y 값을 0으로 설정합니다.

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            /*float angle = Mathf.Atan2(
                this.transform.position.y - mouseWorldPosition.y,
                this.transform.position.x - mouseWorldPosition.x) * Mathf.Rad2Deg;

            float final = (angle + 30f);

            this.transform.rotation = Quaternion.Euler(new Vector3(0f, final, 0f)); */

        }
    }
}