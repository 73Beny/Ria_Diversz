using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class Health : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        public Image healthBar;
        private FirstKillPopupManager popupManager;
        public int enemyType;
        public AudioClip enemyDeathSound;
        private AudioSource audioSource;

        void Start()
        {
            popupManager = FindObjectOfType<FirstKillPopupManager>();
            audioSource = GetComponent<AudioSource>();
        }

        public void Damage(int amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
            }

            this.health -= amount;

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("I am Dead!");
            if (audioSource != null && enemyDeathSound != null)
            {
            Debug.Log("Playing death sound");
            Debug.Log("AudioClip Name: " + enemyDeathSound.name);
            Debug.Log("AudioClip Length: " + enemyDeathSound.length);
            Debug.Log("AudioSource Volume: " + audioSource.volume);
            Debug.Log("AudioSource Mute: " + audioSource.mute);
            audioSource.PlayOneShot(enemyDeathSound);
        }
            else
            {
                Debug.LogWarning("AudioSource or enemyDeathSound is missing!");
            }

            Destroy(gameObject);

            if (popupManager != null)
            {
                popupManager.OnEnemyKilled(enemyType);
            }
        }
    }
