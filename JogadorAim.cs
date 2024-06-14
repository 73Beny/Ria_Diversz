/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorAim : MonoBehaviour
{
   
    private Transform aimTransform;
    private Animator aimAnimator;
    public int damage = 10;

    private void Awake()
    {
        aimTransform = transform.Find("Item_Holder").transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
    }
  
    void Update()
    {
        HandleAiming();
        HandleAtacar();
        
    }

    private void HandleAiming()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - aimTransform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        aimTransform.rotation = rotation;
    }
    /*private void HandleAtacar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aimAnimator.Play("Atacar");
        }
    }*/
/* private void HandleAtacar()
 {
     if (Input.GetMouseButtonDown(0))
     {
         if (!aimTransform.gameObject.activeSelf)
         {
             aimTransform.gameObject.SetActive(true);
         }
         // Determine which animation to play based on the item held
         if (IsItem1Held())
         {
             aimAnimator.Play("Atacar");
         }
         else if (IsItem2Held())
         {
             aimAnimator.Play("Pa");
         }
         else if (IsItem3Held())
         {
             aimAnimator.Play("Rede");
         }
         // Add more conditions as needed for other items/animations
     }
 }

 private bool IsItem1Held()
 {
     // Implement logic to check if item 1 is held
     return true; // Example logic, replace with actual check
 }

 private bool IsItem2Held()
 {
     // Implement logic to check if item 2 is held
     return false; // Example logic, replace with actual check
 }

 private bool IsItem3Held()
 {
     // Implement logic to check if item 3 is held
     return false; // Example logic, replace with actual check
 }


}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorAim : MonoBehaviour
{
    private Transform aimTransform;
    private Animator aimAnimatorAim;
    private Animator aimAnimatorPa;
    private Animator aimAnimatorRede;

    private Animator currentAnimator; 

    private NewBehaviourScript inventoryScript;
    void Awake()
    {
        aimTransform = transform.Find("Item_Holder").transform;

        
        aimAnimatorAim = aimTransform.Find("Aim").GetComponent<Animator>();
        aimAnimatorPa = aimTransform.Find("Pá").GetComponent<Animator>();
        aimAnimatorRede = aimTransform.Find("Rede").GetComponent<Animator>();

        
        aimAnimatorAim.gameObject.SetActive(false);
        aimAnimatorPa.gameObject.SetActive(false);
        aimAnimatorRede.gameObject.SetActive(false);

        
        SetCurrentAnimator(aimAnimatorAim);

        inventoryScript = FindObjectOfType<NewBehaviourScript>();
    }

    void Update()
    {
        HandleAtacar();
    }


    private void HandleAtacar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (IsItemAimHeld())
            {
                SetCurrentAnimator(aimAnimatorAim);
                PlayCurrentAnimator("Atacar", aimAnimatorAim);
            }
            else if (IsItemPaHeld())
            {
                SetCurrentAnimator(aimAnimatorPa);
                PlayCurrentAnimator("Pa", aimAnimatorPa); 
            }
            else if (IsItemRedeHeld())
            {
                SetCurrentAnimator(aimAnimatorRede);
                PlayCurrentAnimator("Rede", aimAnimatorRede); 
            }
        }
    }

    private void SetCurrentAnimator(Animator newAnimator)
    {
       
        if (currentAnimator != null && currentAnimator != newAnimator)
        {
            currentAnimator.gameObject.SetActive(false);
        }

     
        currentAnimator = newAnimator;
        currentAnimator.gameObject.SetActive(true);
    }

    private void PlayCurrentAnimator(string animationName, Animator animator)
    {
     
        if (!animator.enabled)
        {
            animator.enabled = true;
        }

      
        animator.Play(animationName);
    }


    private bool IsItemAimHeld()
    {
        
        return inventoryScript != null && inventoryScript.GetCurrentItemIndex() == 0;
    }

    private bool IsItemPaHeld()
    {
        
        return inventoryScript != null && inventoryScript.GetCurrentItemIndex() == 1;
    }

    private bool IsItemRedeHeld()
    {
        
        return inventoryScript != null && inventoryScript.GetCurrentItemIndex() == 2;
    }
}