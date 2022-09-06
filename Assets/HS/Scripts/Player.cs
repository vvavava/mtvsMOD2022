using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -20;
    public float jumpSpd = 5f;
    float yVelocity = 0;
    Vector3 dir = new Vector3();

    CharacterController cc;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);

        anim.SetFloat("moveSpeed", dir.magnitude);

        if(cc.isGrounded)
        {
            yVelocity = 0;
        }

        //점프키를 눌렀을때 바닥에 닿았다면
        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            //점프 스피드를 높여라
            yVelocity = jumpSpd;
        }
        //계속해서 중력의 영향을 받는다
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * speed * Time.deltaTime);
    }



}
