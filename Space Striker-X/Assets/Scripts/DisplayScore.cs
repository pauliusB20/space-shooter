using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text scoreText;
    GameSession gameSession;
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScoreText();
    }

    private void DisplayScoreText()
    {       
        scoreText.text = gameSession.getScore().ToString();
        
    }
}
