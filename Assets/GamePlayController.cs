using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] float score;
    [SerializeField] float highscore;
    public Color[] template = { new Color32(255, 81, 81, 255), new Color32(255, 129, 82, 255), new Color32(255, 233, 82, 255), new Color32(163, 255, 82, 255), new Color32(82, 207, 255, 255), new Color32(170, 82, 255, 255) };

    private int currentTarget = 0;
    [SerializeField] Image colorImage;
    private int nextTarget = 0;
    [SerializeField] Image colorNextImage;
    private UIController uiController;

    private float time;
    [SerializeField] float timeToChangeColor;
    [SerializeField] float timeOfGame;

    [SerializeField] BackgroundController bgController;
    [SerializeField] AnimalSearching animalSearching;
    private int currentMapIndex;

    private int remainingAnimals;
    private int currentIndex;

    private int currentFiring = 0;
    private float sliderValue;
    private float timeSpaw;
    [SerializeField] float delayTimeSpaw;
    [SerializeField] int maxFire;
    // Start is called before the first frame update
    void Start()
    {
        uiController = GetComponent<UIController>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 10)
        {
            time = 0;
            maxFire++;
        }
        UpdateSlider();

        score += Time.deltaTime;
        UpdateScore();

        timeSpaw += Time.deltaTime;
        if(timeSpaw > delayTimeSpaw)
        {
            RandomSpawFire();
            timeSpaw = 0;
        }
    }

    public void UpdateSlider()
    {
        sliderValue += currentFiring * Time.deltaTime;
        uiController.UpdateSlider(sliderValue);

        if(sliderValue >= timeOfGame)
        {
            GameOver();
        }
    }

    public void SetSlider()
    {
        uiController.SetSlider(timeOfGame);
    }

    public void OnPressHandle()
    {
        currentFiring--;
        sliderValue -= 1f;
    }

    public void GameOver(bool isWin = false)
    {
        Time.timeScale = 0;
        //check fastest time
        
        highscore = PlayerPrefs.GetFloat("time");
        if (highscore < score)
        {
            highscore = score;
            PlayerPrefs.SetFloat("time", highscore);
        }

        uiController.GameOver(isWin);
    }

    public void UpdateScore()
    {
        uiController.UpdateScore(score);
    }

    public void SetCurrentTarget()
    {
        animalSearching.SetTarget(currentTarget);
    }

    public void RandomMap()
    {
        currentMapIndex = bgController.HandleShowBG();
        RandomSpawFire();
    }

    public void RandomSpawFire()
    {
        int fire = Random.Range(1, maxFire);
        bgController.SpawAnimals(fire);
        currentFiring += fire;
    }

    public void Reset()
    {
        Time.timeScale = 1;

        currentTarget = 0;
        RandomMap();
        currentIndex = 0;
        time = 0;
        SetSlider();
        score = 0;
        highscore = PlayerPrefs.GetFloat("time");
        uiController.UpdateScore(score);
        uiController.UpdateHighScore(highscore);
        //uiController.UpdateHighScore(highscore);
    }

}
