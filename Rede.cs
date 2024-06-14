using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rede : MonoBehaviour
{
    private Collider2D lastEnemyCollision;
    private bool isOnCooldown = false;
    public float cooldownDuration = 2f;
    private Animator animator; 

    private void Start()
    {

        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            lastEnemyCollision = collision;
        }
    }

    private void Update()
    {
         if (Input.GetMouseButtonDown(0) && lastEnemyCollision != null && !isOnCooldown)
        {
            animator.Play("Rede");

            Destroy(lastEnemyCollision.gameObject);
            Debug.Log("Destroyed enemy: " + lastEnemyCollision.gameObject.name);
            lastEnemyCollision = null;

            StartCooldown();
        }
    }

    private void StartCooldown()
    {
        isOnCooldown = true;
        Invoke(nameof(ResetCooldown), cooldownDuration);
    }

    private void ResetCooldown()
    {
        isOnCooldown = false;
    }
}

