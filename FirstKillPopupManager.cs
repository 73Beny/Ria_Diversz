using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstKillPopupManager : MonoBehaviour
{
    public GameObject[] enemyKillPopups; 
    private bool[] hasShownPopup; 

    void Start()
    {
        hasShownPopup = new bool[enemyKillPopups.Length];

        for (int i = 0; i < enemyKillPopups.Length; i++)
        {
            if (enemyKillPopups[i] != null)
            {
                enemyKillPopups[i].SetActive(false);
            }
            else
            {
                Debug.LogError("EnemyKillPopup is not assigned in the inspector at index " + i);
            }
        }
    }

    public void OnEnemyKilled(int enemyType)
    {
        Debug.Log("Enemy killed of type: " + enemyType);

        if (enemyType < 0 || enemyType >= enemyKillPopups.Length)
        {
            Debug.LogError("Invalid enemy type: " + enemyType);
            return;
        }

        if (!hasShownPopup[enemyType])
        {
            hasShownPopup[enemyType] = true;
            if (enemyKillPopups[enemyType] != null)
            {
                Debug.Log("Showing pop-up for enemy type: " + enemyType);
                enemyKillPopups[enemyType].SetActive(true); 
                StartCoroutine(HidePopupAfterDelay(enemyKillPopups[enemyType], 3.0f)); 
            }
        }
    }

    private IEnumerator HidePopupAfterDelay(GameObject popup, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (popup != null)
        {
            popup.SetActive(false);
        }
    }
}
