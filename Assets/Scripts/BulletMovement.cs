using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        //Esta sencilla función hará que la bala avance hacia adelante
        transform.position = transform.position + transform.up * speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        ObstacleLife life;
        if (col.gameObject.TryGetComponent<ObstacleLife>(out life) && life.life < 1)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else
            life.life--;
    }
}