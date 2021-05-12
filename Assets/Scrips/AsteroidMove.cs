using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        moveAsteroid();
    }

    void moveAsteroid()
    {
        this.transform.position = this.transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
    }
}
