using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AttackArea : MonoBehaviour
{

    public int damage;

     private void OnTriggerEnter2D(Collider2D collider)
     {
         if (collider.GetComponent<Health>() != null)
         {
             Health health = collider.GetComponent<Health>();
             health.Damage(damage);
         }
     }
}
