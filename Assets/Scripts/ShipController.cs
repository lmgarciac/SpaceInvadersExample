using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    public AudioSource shootingSound; //Declaramos la nueva variable de fuente de sonido

    public float speed = 1f;

    // Se llama a Start antes de la primera actualización del cuadro

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(moveHorizontal, 0f);

        if (Input.GetKey(KeyCode.Space))
        {
            shootingSound.Play();
        }
    }

    // FixedUpdate se llama en cada fixed frame-rate frame. (50 llamadas por segundo, por defecto)
    void FixedUpdate()
    {
        // Aplica la fuerza al Rigidbody2d
        rigidbody.AddForce(movement * speed * 5f);
    }
}