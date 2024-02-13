using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject GameOverUI;
    private int totalScore = 0;

    private void SetScoreText(int score){
        totalScore += score;
        scoreText.text = totalScore + "";
    }

    private void ShowGameOver(){
        GameOverUI.active = true;
    }

    private void OnEnable(){
        Enemy.ExplodingEvent += SetScoreText;
        ShipController.GameOverEvent += ShowGameOver;
    }

    private void OnDisable(){
        Enemy.ExplodingEvent -= SetScoreText;
        ShipController.GameOverEvent -= ShowGameOver;
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ReplayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
