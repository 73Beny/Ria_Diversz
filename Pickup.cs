using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pickupText;

    [SerializeField]
    private TextMeshProUGUI moneyText;

    private bool pickUpAllowed;
    private bool isTimerRunning;
    private float timer;
    public int money;

    void Start()
    {
        pickupText.gameObject.SetActive(false);
        moneyText.gameObject.SetActive(false);
        isTimerRunning = false;
        timer = 0f;
    }

    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            moneyText.text = "+" + money;
            moneyText.gameObject.SetActive(true);
            Debug.Log("Money text. começar timer");
            isTimerRunning = true;
            timer = 0f; 
        }

        if (isTimerRunning)      //não desaparece o texto amarelo
        {
            timer += Time.deltaTime;
            if (timer >= 2.0f)
            {
                moneyText.gameObject.SetActive(false);
                Debug.Log("Timer chegou aos 2. Hide money text.");
                isTimerRunning = false;
                Canvas.ForceUpdateCanvases();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickupText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickupText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
        Debug.Log("Picked up the item and destroyed the game object.");
    }
}
