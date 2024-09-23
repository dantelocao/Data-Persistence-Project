using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuBestScore : MonoBehaviour
{
    public Text BestScoreText;

    public void Start()
    {
        SetBestScore();
    }

    public void SetBestScore()
    {
        ScenesDataManager.SaveData bestPlayer = new ScenesDataManager.SaveData();
        bestPlayer = ScenesDataManager.instance.LoadPlayerData();
        if (bestPlayer != null)
        {
            BestScoreText.text = "Best Score : " + bestPlayer.playerPoints + " pontos de " + bestPlayer.playerName;
        } 
        else
        {
            BestScoreText.text = "No Best Score";
        }
    }
}
