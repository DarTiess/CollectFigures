using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject takePlace;
    bool takenFigure;
    GameObject figureInHand;
    Vector3 startPosition;

    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
       
    }

    private void Start()
    {
       
    startPosition = transform.position; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!takenFigure)
            {
                CheckFigureAround(gameObject.transform.position, 2f);
               // OnCheckForward();
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
                    SoundManager.Instance.PlaySound(SoundManager.Sound.GetFigure);
                    hitCollider.GetComponent<Figure>().taken = true;

                    hitCollider.transform.position = takePlace.transform.position;
                    hitCollider.transform.parent = takePlace.transform;
                    figureInHand = hitCollider.gameObject;
                }
            }
           
        }
    }
    public void OnCheckForward()
    {
       
        Ray ray = new Ray(takePlace.transform.position - new Vector3(0,0.54f,0), takePlace.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider != null)
            {

                if (hit.transform.gameObject.CompareTag("Cube") || hit.transform.gameObject.CompareTag("Sphere") || hit.transform.gameObject.CompareTag("Capsul"))
                {
                    if (!takenFigure)
                    {
                        takenFigure = true;
                        hit.transform.gameObject.GetComponent<Figure>().taken = true;

                        hit.transform.position = takePlace.transform.position;
                        hit.transform.parent = takePlace.transform;
                        figureInHand = hit.transform.gameObject;
                    }

                }
               
            }

            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
    void PlacedFigure()
    {
       if(figureInHand.GetComponent<Figure>().findPlace)
        {
            figureInHand.tag = figureInHand.tag + "InHand";
            GameManager.Instance.AddFigure(figureInHand.tag);
            SoundManager.Instance.PlaySound(SoundManager.Sound.PushOnPlace);
            Destroy(figureInHand);
            
            takenFigure = false;
        }
    }

    public void RestartPlayer()
    {
        transform.position = startPosition;
        
    }

}
