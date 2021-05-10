using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorTrigger : MonoBehaviour
{    
    private Animation _animation;

    private void Start() 
    {
        _animation = gameObject.GetComponentInChildren<Animation>();         
    }

     private void OnTriggerEnter(Collider collision) 
     {         
         if (collision.TryGetComponent<PlayerMover>(out PlayerMover player)) 
         {
             _animation.Play("DoorOpen");             
         }         
     }

    private void OnTriggerExit(Collider collision) 
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player)) 
        {
            _animation.Play("DoorClose");             
        }
    }
}
