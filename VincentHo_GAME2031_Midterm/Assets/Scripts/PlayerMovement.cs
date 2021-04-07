using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    private Rigidbody2D m_rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField]
    private Vector2 m_vLeftVel;

    [SerializeField]
    private Vector2 m_vRightVel;

    private Vector2 m_vCurrentVel;
    private float m_fvelMag;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_vCurrentVel = m_rb.velocity;
        m_fvelMag = Mathf.Abs(m_vCurrentVel.magnitude);
        animator.SetFloat("Velocity", m_fvelMag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            gameObject.transform.position = spawnPoint.position;
        } 
        else
        {
            m_rb.velocity = Vector2.zero;
        }
    }

    public void moveLeft()
    {
        spriteRenderer.flipX = true;
        m_rb.AddForce(m_vLeftVel, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }
    public void moveRight()
    {
        spriteRenderer.flipX = false;
        m_rb.AddForce(m_vRightVel, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }
}
