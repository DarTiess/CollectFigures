using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] figures;
    public int figureAmount;
    float zPos, xPos;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GenerateFigures", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateFigures()
    {
        int rndFigure;
        for(int i = 0; i < figureAmount; i++)
        {
            rndFigure = Random.Range(0, figures.Length);
            xPos = Random.Range(8.41f, -29.22f);
            zPos = Random.Range(6.57f, -6.64f);

            Instantiate(figures[rndFigure], new Vector3(xPos, 1.4f, zPos), figures[rndFigure].transform.rotation);
        }
    }
}
