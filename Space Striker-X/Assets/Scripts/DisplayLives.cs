using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLives : MonoBehaviour
{
    // Start is called before the first frame update
    Text liveText;
    Player player;
    void Start()
    {
        liveText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLivesText();
    }

    private void DisplayLivesText()
    {
        liveText.text = player.getHealth().ToString();
    }
}
