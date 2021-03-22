using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBullet : MonoBehaviour
{
    public GameObject bullet;

    public void NewBall()
    {
        Instantiate(bullet, new Vector3(-5f, -1f, 0f),Quaternion.identity);
    }
}
