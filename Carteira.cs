using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Carteira : MonoBehaviour
{
    private bool pickUpAllowed;
    private int carteira;
    public TextMeshProUGUI dinheiro;
    private Pickup myobject;

    void Start()
    {
        PlayerPrefs.SetInt("Total", 0); 
        carteira = PlayerPrefs.GetInt("Total", 0); 
        dinheiro.text = carteira.ToString();
    }

    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            carteira += myobject.money; 
            Debug.Log("Dinheiro Atual: " + carteira);
            PlayerPrefs.SetInt("Total", carteira);
            dinheiro.text = carteira.ToString(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            pickUpAllowed = true;
            myobject = collision.GetComponent<Pickup>(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            pickUpAllowed = false;
            myobject = null; 
        }
    }
}
