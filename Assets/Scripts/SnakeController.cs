using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float velocity;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spRd;
    private int saltosRestantes;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spRd = GetComponent<SpriteRenderer>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if(EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        // Rigidbody2D body = GetComponent<Rigidbody2D>();
        if(inputMovimiento != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        body.velocity = new Vector2(inputMovimiento * velocity, body.velocity.y);
        GestionarOrientacion(inputMovimiento);

    }

    void GestionarOrientacion(float inputMovimiento)
    {
        if (inputMovimiento > 0)
        {
            spRd.flipX = false;
        }
        else if (inputMovimiento < 0)
        {
            spRd.flipX = true;
        }

    }
}
