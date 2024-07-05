using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float turn_speed = 350f;
    [SerializeField] float move_speed = 20f;

    [SerializeField] float slow_speed = 15f;

    [SerializeField] float boost_speed = 30f;



    // Update is called once per frame
    void Update()
    {
        
        float turn_amount = Input.GetAxis("Horizontal") * turn_speed * Time.deltaTime;
        float move_amount = Input.GetAxis("Vertical") * move_speed * Time.deltaTime;
        transform.Rotate(0,0,-turn_amount);
        transform.Translate(0,move_amount,0);

    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        move_speed = slow_speed;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        move_speed = 20f;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost"){
            move_speed = boost_speed;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Boost"){
            move_speed = 20f;
        }
    }
}
