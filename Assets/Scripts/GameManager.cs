using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI cubeCount;
    public TextMeshProUGUI sphereCount;
    public TextMeshProUGUI capsulCount;

    int cubeCountInt;
    int sphereCountInt;
    int capsulCountInt;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cubeCountInt = 0;
        sphereCountInt = 0;
        capsulCountInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cubeCount.text = cubeCountInt.ToString();
        sphereCount.text = sphereCountInt.ToString();
        capsulCount.text = capsulCountInt.ToString();
    }

    public void AddFigure(string tagName)
    {
        switch (tagName)
        {
            case "Sphere":
                sphereCountInt++;
                break;
            case "Cube":
                cubeCountInt++;
                break;
            case "Capsul":
                capsulCountInt++;
                break;
        }
    }

}
