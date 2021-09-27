using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [HideInInspector]public bool taken;
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
        }
       
    }
}
