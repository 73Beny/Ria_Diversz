using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Image healthBar;
    public GameManager gameManager;
    private bool isDead;


    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);  

       if(health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Destroy(gameObject);
        }
     }
  
}
