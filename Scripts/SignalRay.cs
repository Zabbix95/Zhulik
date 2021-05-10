using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SignalRay : MonoBehaviour
{       
    private AudioSource _signalization;    
    
    void Start()
    {
        _signalization = GetComponent<AudioSource>();        
    }

    void FixedUpdate()
    {
        RaycastHit signalRay;
        Physics.Raycast(transform.position, transform.forward, out signalRay);        
        if (signalRay.collider.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            if (_signalization.isPlaying == false) 
            {
                _signalization.volume = 0;
                
                _signalization.Play();
            } 
            else 
            {
                 _signalization.volume += Mathf.Lerp(0, 1, Time.deltaTime * 0.1f);
            }                                  
        }
        else 
        {                      
            _signalization.volume -= Mathf.Lerp(0, 1, Time.deltaTime * 0.1f);

            if (_signalization.volume != 0) 
            {
                Debug.Log(_signalization.volume);
            }
        }        
    }    
}
