using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStateManager : MonoBehaviour
{
    [SerializeField] Text gameStateTextUI;
    [SerializeField] Text msgTextUI;

    [SerializeField] List<string> gameStateTexts;
    [SerializeField] List<string> gameMsgTexts;

    enum GameStateMessages { levelWonStateText, levelLostStateText }
    // Start is called before the first frame update
    void Start()
    {
       

        var gs = FindObjectOfType<GameSession>();
        if (gs != null)
        {
            if (gs.LevelWon())
            {
                gameStateTextUI.text = gameStateTexts[(int)GameStateMessages.levelWonStateText];
                msgTextUI.text = gameMsgTexts[(int)GameStateMessages.levelWonStateText];
            }
            else
            {
                gameStateTextUI.text = gameStateTexts[(int)GameStateMessages.levelLostStateText];
                msgTextUI.text = gameMsgTexts[(int)GameStateMessages.levelLostStateText];
            }
        }
    }

   
}
