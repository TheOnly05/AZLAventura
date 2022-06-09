using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmenVargas : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rcv;

    bool isForward; bool isbackward;
    public float velAndar = 0.15f;

    
     void Start()
    {
        anim = GetComponent<Animator>();
        rcv = GetComponent<Rigidbody2D>();
    }

    public void PointerDownForward()
    {
        isForward = true;
        anim.SetBool("isWalk", isForward);
    }
    public void PointerUpForward()
    {
        isForward = false;
        //anim.SetBool("isWalk", false);
    }
    public void PointerDownBackward()
    {
        isbackward = true;
        anim.SetBool("isWalk", isbackward);
    }
    public void PointerUpBackward()
    {
        isbackward = false;
        //anim.SetBool("isWalk", false);
    }

     void FixedUpdate()
    {
        if (isForward)
        {
            MovForward();
            
        }
        if (isbackward)
        {
            MovBackward();
        }
    }
    public void MovForward()
    {
       // rcv.velocity = new Vector2(400f, rcv.velocity.y);
        transform.Translate(new Vector3(velAndar, 0, 0));
    }
    public void MovBackward()
    {
        // rcv.velocity = new Vector2(400f, rcv.velocity.y);
        transform.Translate(new Vector3(-velAndar, 0, 0));
    }
}
