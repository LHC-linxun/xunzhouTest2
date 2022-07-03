using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rig;
    public bool isGetMouseButton;
    private Animator animator;
    private Ball ball;
    Vector3 vector;
    private BouncingBall bouncingBall;
    // Start is called before the first frame update
    void Start()
    {
        float vy = Mathf.Sqrt(Mathf.Abs(Physics.gravity.y * 2));

        vector = Vector3.up * vy;
        rig = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        ball = GameObject.Find("Sphere").GetComponent<Ball>();
        bouncingBall = GameObject.Find("ProduceManager").GetComponent<BouncingBall>();
    }

    // Update is called once per frame
    void Update()
    {
        ImputFunction();
    }

    private void ImputFunction()
    {
        //鼠标左键或者长按屏幕
        if (Input.GetMouseButton(0))
        {
            isGetMouseButton = true;

         //   Debug.Log("1111111111");
        }
        else
        {
            isGetMouseButton = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
       
        if(isGetMouseButton)
        {
            rig.velocity = -vector*2;
            if (collision.transform.tag == "WhileChild")
            {
                bouncingBall.curprefabList.Remove(collision.transform.parent.gameObject);
                Destroy(collision.transform.parent.gameObject);
            }
            else
            {
                Destroy(ball.gameObject);
            }
        }       
        else
        {

            animator.SetTrigger("OnWall");

           
            rig.velocity = vector;
        }
    }
}
