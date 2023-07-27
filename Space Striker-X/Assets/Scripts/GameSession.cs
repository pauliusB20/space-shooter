using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    [SerializeField] int Score = 0;
    [SerializeField] bool isLevelWon = false;
    [SerializeField] int maxScore = 100;
    private void Awake()
    {
        int GameSessionNumber = FindObjectsOfType(GetType()).Length;

        if (GameSessionNumber > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        if (isLevelWon) return;

        if (Score >= maxScore)
            isLevelWon = !isLevelWon;

    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
   
  

    public int getScore()
   {
       return Score;
   }
  
   public void AddToScore(int points)
   {
       Score += points;
   }
  
   public bool LevelWon()
   {
        return isLevelWon;
   }
    




}
