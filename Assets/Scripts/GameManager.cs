using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SpawnManager spawnManager;
    public CanvasGroup startGroupe;
    public CanvasGroup playGroupe;
    public CanvasGroup winGroupe;
   

    public TextMeshProUGUI cubeCount;
    public TextMeshProUGUI sphereCount;
    public TextMeshProUGUI capsulCount;  
    
    public TextMeshProUGUI cubeFinal;
    public TextMeshProUGUI sphereFinal;
    public TextMeshProUGUI capsulFinal;

    int cubeCountInt;
    int sphereCountInt;
    int capsulCountInt;

    int cubeInScene=10;
    int sphereInScene=10;
    int capsulInScene=10;
    [HideInInspector] public bool isGaming;


    private void Awake()
    {
        Instance = this;
    }
  
    // Start is called before the first frame update
    void Start()
    {
        OnCanvasGroupe("Start");
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
    public void StartGame()
    {
        OnCanvasGroupe("Play");
       
    }

    public void OnCanvasGroupe(string nameCanvas)
    {
        switch (nameCanvas)
        {
            case "Start":
                LockRestCanvases(startGroupe);
              
                break;
            case "Play":
                isGaming = true;
                LockRestCanvases(playGroupe);
                Debug.Log("on play");
                break;
            case "Win":
                isGaming = false;
                LockRestCanvases(winGroupe);
                break;

        }
    }
    void LockRestCanvases(CanvasGroup canvasgr)
    {
        CanvasGroup[] canvasGroupes = GameObject.FindObjectsOfType<CanvasGroup>();
        foreach (CanvasGroup cGr in canvasGroupes)
        {

            cGr.alpha = 0;
            cGr.interactable = false;
            cGr.blocksRaycasts = false;

        }
        canvasgr.alpha = 1;
        canvasgr.interactable = true;
        canvasgr.blocksRaycasts = true;
       

    }
    public void WinGame()
    {
        cubeFinal.text = cubeCountInt.ToString();
        sphereFinal.text = sphereCountInt.ToString();
        capsulFinal.text = capsulCountInt.ToString();
        OnCanvasGroupe("Win");

    }
    public void RestartGame()
    {
        PlayerController.Instance.RestartPlayer();
        spawnManager.GenerateFigures();
      
        OnCanvasGroupe("Play");

    }


    public void QuiteGame()
    {
        Application.Quit();
    }
    public void AddFigure(string tagName)
    {
        switch (tagName)
        {
            case "SphereInHand":
                sphereCountInt++;
              
                Debug.Log("Sphere " + sphereInScene);
                break;
            case "CubeInHand":
                cubeCountInt++;
              
                Debug.Log("Cube " + cubeInScene);
                break;
            case "CapsulInHand":
                capsulCountInt++;
              
                Debug.Log("Capsul " + capsulInScene);
                break;
        }
        sphereInScene = CheckFigureOnScene("Sphere");
        cubeInScene = CheckFigureOnScene("Cube");
        capsulInScene = CheckFigureOnScene("Capsul");
        if ((capsulInScene==0) && sphereInScene==0 && cubeInScene == 0)
        {
            WinGame();
        }
    }

   public int CheckFigureOnScene( string tagFigure)
    {
       int figureInScene = GameObject.FindGameObjectsWithTag(tagFigure).Length;
        return figureInScene;
    }
}
