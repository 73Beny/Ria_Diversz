using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject itemHolder; 
    public GameObject inventoryImage; 

    private bool menuActivated;
    private Transform[] items;    

    private int currentItemIndex = 0; 

    void Start()
    {
        
        items = new Transform[itemHolder.transform.childCount];
        for (int i = 0; i < itemHolder.transform.childCount; i++)
        {
            items[i] = itemHolder.transform.GetChild(i);
        }

        for (int i = 0; i < items.Length; i++)
        {
            items[i].gameObject.SetActive(i == currentItemIndex);
        }

        UpdateInventoryImage(currentItemIndex);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            menuActivated = !menuActivated;
            Time.timeScale = menuActivated ? 0 : 1;
            InventoryMenu.SetActive(menuActivated);

            if (menuActivated)
            {
                UpdateInventoryImage(currentItemIndex);
            }
            else
            {
                UpdateInventoryImage(currentItemIndex);
            }
        }


        if (menuActivated)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchToItem(0); 
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchToItem(1); 
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchToItem(2); 
            }
        }
    }

    void SwitchToItem(int newIndex)
    {
        items[currentItemIndex].gameObject.SetActive(false);
               
        items[newIndex].gameObject.SetActive(true);
              
        currentItemIndex = newIndex;

        UpdateInventoryImage(currentItemIndex);
    }

    void UpdateInventoryImage(int index)
    {
        Sprite itemSprite = items[index].GetComponent<SpriteRenderer>().sprite;
        inventoryImage.GetComponent<Image>().sprite = itemSprite;
    }

    public int GetCurrentItemIndex()
    {
        return currentItemIndex;
    }
}

