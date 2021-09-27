using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject takePlace;
    bool takenFigure;
    GameObject figureInHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!takenFigure)
            {
                CheckFigureAround(gameObject.transform.position, 5f);
            }
            else
            {
                PlacedFigure();
            }
        }
    }

    void CheckFigureAround(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Cube") || hitCollider.CompareTag("Sphere") || hitCollider.CompareTag("Capsul"))
            {
                if (!takenFigure)
                {
                    takenFigure = true;
                    hitCollider.GetComponent<Figure>().taken = true;

                    hitCollider.transform.position = takePlace.transform.position;
                    hitCollider.transform.parent = takePlace.transform;
                    figureInHand = hitCollider.gameObject;
                }
            }
           
        }
    }

    void PlacedFigure()
    {
       if(figureInHand.GetComponent<Figure>().findPlace)
        {
            figureInHand.SetActive(false);
            takenFigure = false;
        }
    }
}
