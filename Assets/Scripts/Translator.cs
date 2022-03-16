using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Translator : MonoBehaviour
{
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void Stop()
    {
        StartCoroutine(StopMovement());
    }

    private IEnumerator StopMovement()
    {
        float param = 0;

        while(param < 1f)
        {
            rb.velocity -= new Vector2(0.1f, 0.1f);
            Debug.Log($"rb.velocity {rb.velocity}");
            param += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }


}

