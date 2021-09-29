using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [HideInInspector]public bool taken;
    [HideInInspector] public bool findPlace;
    public ParticleSystem shineEffect;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!taken)
        {
            transform.Rotate(Vector3.up, 100f * Time.deltaTime);
           // shineEffect.Play();
        }
        else
        {
            shineEffect.Stop();
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(gameObject.transform.tag + "Place"))
        {
            findPlace = true;
          
            Debug.Log(gameObject.tag + " is on place");
        }
        else
        {
            findPlace = false;
        }
    }

}
