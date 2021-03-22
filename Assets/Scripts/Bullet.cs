using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    NewBullet newB;

    private bool grounded = false;
    private bool pointerPressed = false;
    private float releaseTime = .2f;
    private float xVelocity;

    private void Start()
    {
        newB = GameObject.FindWithTag("Respawn").GetComponent<NewBullet>();
        grounded = false;
    }
    private void Update()
    {
        xVelocity = rb.velocity.x;
        Debug.Log(xVelocity);
        if (pointerPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void OnMouseDown()
    {
        pointerPressed = true;
    }
    private void OnMouseUp()
    {
        pointerPressed = false;
        rb.isKinematic = false;
        StartCoroutine(DropThatBall());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!grounded && xVelocity < .5f && xVelocity > -0.5f)
        {
            StartCoroutine(NewBullet());
            grounded = true;
        }
    }
    IEnumerator DropThatBall()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
    }

    IEnumerator NewBullet()
    {
        yield return new WaitForSeconds(1f);
        newB.NewBall();
        StopCoroutine(NewBullet());
    }

}
