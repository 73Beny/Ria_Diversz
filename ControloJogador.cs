using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ControloJogador : MonoBehaviour
{
    private Transform pTransform;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 forceToApply;
    public Vector2 PlayerInput;
    public float forceDamping;

    private Animator anim;
    private bool facingRight = true;

    void Start()
    {
        pTransform = this.transform;
    }

    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;
        CheckForFlipping();
    }

    private void CheckForFlipping()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < pTransform.position.x && facingRight)
        {
            Flip();
        }
        else if (mousePosition.x > pTransform.position.x && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = pTransform.localScale;
        localScale.y *= -1;
        pTransform.localScale = localScale;
    }

    void Update()
    {
        Direcao();
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void Direcao()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        pTransform.rotation = rotation;
    }
}

