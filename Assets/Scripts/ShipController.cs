using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    public AudioSource shootingSound;
    public GameObject bullet;

    public float speed = 1f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(moveHorizontal, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Acá lo importante es aprender la función Instatiate(). En este caso
            // el primer parámetro el Prefab que queremos instanciar, el segundo
            // parámetro es la posición donde lo vamos instanciar (en este caso la posición de la nave)
            // y el tercero es la rotación del Prefab que se está instanciando.
            Instantiate(bullet, transform.position + Vector3.up, transform.rotation);
            shootingSound.Play();
        }
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(movement * speed * 5f);
    }
}