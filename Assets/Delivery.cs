using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
   bool package_picked_up;

   [SerializeField] Color32 has_no_package_color = new Color32(1,1,1,1);
   [SerializeField] Color32 has_package_color = new Color32(1,1,1,1);

   [SerializeField] float destroy_delay = 0.5f;

   SpriteRenderer spriteRenderer;

   
   private void Start(){
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
   void OnCollisionEnter2D(Collision2D other){

    Debug.Log("Insurance is going to be a mess!");
    
   }

   void OnTriggerEnter2D(Collider2D other){
    
      if(other.tag == "Package" && !package_picked_up){
         Debug.Log("Package picked up!");
         package_picked_up = true;
         spriteRenderer.color = has_package_color;
         Destroy(other.gameObject, destroy_delay);
   
         
      }else if (other.tag == "Customer" && package_picked_up){
         Debug.Log("Package Delivered!");
         package_picked_up = false;
         spriteRenderer.color = has_no_package_color;
      }
   }
}
