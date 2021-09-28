using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rig.velocity = transform.forward * speed;
    }
}
