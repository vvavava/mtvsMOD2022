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

        //����Ű�� �������� �ٴڿ� ��Ҵٸ�
        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            //���� ���ǵ带 ������
            yVelocity = jumpSpd;
        }
        //����ؼ� �߷��� ������ �޴´�
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * speed * Time.deltaTime);
    }



}
