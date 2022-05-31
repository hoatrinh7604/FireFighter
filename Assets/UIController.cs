using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject confirm;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highscore;

    [SerializeField] TextMeshProUGUI gameOverTitle;

    [SerializeField] GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        confirm.SetActive(false);
    }

    public void SetSlider(float value)
    {
        slider.GetComponent<SliderController>().SetSlider(value);
    }

    public void UpdateSlider(float value)
    {
        slider.GetComponent<SliderController>().UpdateSlider(value);
    }

    public void GameOver(bool isWin = false)
    {
        gameOver.SetActive(true);
        if(isWin)
        {
            gameOverTitle.text = "You win the scene!!!";
            gameOverTitle.color = new Color(0.12f, 1, 0, 1);
        }
        else
        {
            gameOverTitle.text = "Game over!!!";
            gameOverTitle.color = new Color(1, 0, 0.04f, 1);
        }
    }

    public void Confirm(bool isShow)
    {
        Time.timeScale = (isShow) ? 0 : 1;
        confirm.SetActive(isShow);
    }

    public void BackToMenu()
    {
        GetComponent<SceneController>().BackToMenu();
    }

    public void Restart()
    {
        GetComponent<SceneController>().Restart();
    }

    public void Quit()
    {
        GetComponent<SceneController>().Quit();
    }

    public void UpdateScore(float score)
    {
        this.score.text = FloatToTime(score);
    }

    public void UpdateHighScore(float score)
    {
        this.highscore.text = FloatToTime(score);
    }

    private string FloatToTime(float time)
    {
        int min = (int)time / 60;
        return min + "m" + ((int)time - 60*min) + "s";
    }
}
