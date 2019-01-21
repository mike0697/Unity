using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : Singleton<Manager> {

    public int winningPoints = 3;
    public int[] scores;

    public List<Transform> spawnpoint;
    public List<GameObject> bottles;
    GameObject activeBottle;

    public Text startCanvasText;
    public GameObject nutty;
    public GameObject trash;
    public GameObject gear;

    public GameObject startCanvas;
    public GameObject optionCanvas;

    public Sprite normalSprite, ripSprite, happySprite, angrySprite;
    public Image optionNuttyImage;

    public GameObject resumeButton, nextLevelButton;

    bool wantStart;
    bool hasWin;
    private void Awake()
    {
        OnReload();
    }
    void Start () {
        scores = new int[bottles.Count];
        StartCoroutine(MainRoutine());
	}

    IEnumerator MainRoutine()
    {
        // prima fase di esecuzione in cui si aspetta che il giocatore prema play
        yield return StartCoroutine(StartPhase());
        // seconda fase di gioco in cui si attende la vincita o la sconfitta
        yield return StartCoroutine(MainPhase());
        //controllo sull ésito della partita
        optionCanvas.SetActive(true);
        resumeButton.SetActive(false);
        if(!hasWin)
        {
            AudioManager.Instance.PlayLoseSound();
            optionNuttyImage.sprite = ripSprite;
            optionCanvas.GetComponentInChildren<Text>().text = "RIP! \n Nutty ha un pelo esagerato. ";
            nextLevelButton.SetActive(false);
        }
        else
        {
            AudioManager.Instance.PlayLoseSound();
            optionNuttyImage.sprite = happySprite;
            optionCanvas.GetComponentInChildren<Text>().text = "Complimenti! Procedi al prossimo livello";
            nextLevelButton.SetActive(true);
        }
    }

    IEnumerator StartPhase()
    {
        //Disattiviamo/Attivare tutti i gameobject che ci servono attivare -> startcanvas
        nutty.SetActive(false);
        trash.SetActive(false);
        gear.SetActive(false);
        startCanvas.SetActive(true);
        nextLevelButton.SetActive(false);
        scores = new int[bottles.Count];
        startCanvasText.text = "Devi bere " + winningPoints + " bottiglie";

        //Attendere che il giocatore prema play
        while (!wantStart)
            yield return null;
        //Una volta premuto play riattiviamo tutti gli elementi del gioco disattivati e disattiviamo canvas
        wantStart = false;
        nutty.SetActive(true);
        trash.SetActive(true);
        gear.SetActive(true);
        startCanvas.SetActive(false);
        
    }

    IEnumerator MainPhase()
    {
        spawnBottle();
        bool endPhase = false;
        while (!endPhase)
        {
            hasWin = false;
            //controlliamo se uno score ha superato il limite
            foreach (var score in scores)
            {
                if (score > winningPoints)
                {
                    print("Hai Perso");
                    hasWin = false;
                    endPhase = true;
                    break;
                }
            }
            //controlliamo se tutti gli score sono uguali al winning point, 
            if (!endPhase)
            {
                foreach (var score in scores)
                {
                    if (score == winningPoints)
                    {
                        hasWin = true;
                        endPhase = true;
                    }
                    else
                    {
                        print("continua");
                        hasWin = false;
                        endPhase = false;
                        break;
                    }
                }
            }

            yield return null;
        }
        if (hasWin)
            print("Hai vinto");
    }

    public void spawnBottle()
    {
        if (activeBottle != null)
            Destroy(activeBottle);

        int spawnIndex = Random.Range(0, spawnpoint.Count); // ultime elemento escuso 
        int bottleIndex = Random.Range(0, bottles.Count);

        activeBottle = Instantiate(bottles[bottleIndex], spawnpoint[spawnIndex]);


        
    }

    public void StartGame()
    {
        wantStart = true;
    }

    public void Score(int bottleIndex)
    {
        scores[bottleIndex]++;
        AudioManager.Instance.PlayDrinkSound();
        
    }

    public void Pause()
    {
        HandleSceneObject(false);
        optionCanvas.SetActive(true);
        resumeButton.SetActive(true);
        optionNuttyImage.sprite = angrySprite;
        optionCanvas.GetComponentInChildren<Text>().text = "Opzioni!";


    }

    public void Resume()
    {
        HandleSceneObject(true);
        optionCanvas.SetActive(false);
        
    }
    public void Restart()
    {
        //Restart applicativo 
        scores = new int[bottles.Count];
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

    void HandleSceneObject(bool wantActive)
    {
        activeBottle.SetActive(wantActive);
        nutty.SetActive(wantActive);
        trash.SetActive(wantActive);
        gear.SetActive(wantActive);
    }

    public void NextLevel()
    {
        winningPoints = winningPoints * 2;
        optionCanvas.SetActive(false);
        scores = new int[bottles.Count];
        StartCoroutine(MainRoutine());

    }
}
