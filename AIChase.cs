using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AIChase : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    public healthbar pHealth;
    public float damage;



    void Start()
    {
        targetPoint = 0;
    }


    private void Update()
    {
        transform.right =  patrolPoints[targetPoint].position - transform.position;
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();

        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void increaseTargetInt()
    {
        targetPoint++;
        flip();

        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            other.gameObject.GetComponent<healthbar>().health -=damage;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;
    }

}
