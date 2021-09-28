using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;    
}

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Header("Movimiento Jugador")]
    [Range(5, 13)] public float value;
    public Rigidbody rigid;
    public float Jumpv = 15f;
    public float thrust = 30;
    bool m_isGrounded;


    [Header("Shooting")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        m_isGrounded = true;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;    
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }


    void FixedUpdate()
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Right") && m_isGrounded == true)
        {
            if (value == 20
                )
                return;
            value += 20;
        }
        if (Input.GetButtonDown("Left") && m_isGrounded == true)
        {
            if (value == -20)
                return;
            value -= 20;
        }
    }

    public void Jump()
    {
        rigid.AddForce(0, thrust, 0, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Grounded"))
        {
            m_isGrounded = true;
        }
    }
}
