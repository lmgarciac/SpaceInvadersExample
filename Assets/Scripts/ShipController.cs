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
            //Ac� lo importante es aprender la funci�n Instatiate(). En este caso
            // el primer par�metro el Prefab que queremos instanciar, el segundo
            // par�metro es la posici�n donde lo vamos instanciar (en este caso la posici�n de la nave)
            // y el tercero es la rotaci�n del Prefab que se est� instanciando.
            Instantiate(bullet, transform.position + Vector3.up, transform.rotation);
            shootingSound.Play();
        }
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(movement * speed * 5f);
    }
}