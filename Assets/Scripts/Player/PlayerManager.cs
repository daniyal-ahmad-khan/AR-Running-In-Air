using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject startingText;
    public static bool isGameStarted;
    public static int numberOfCoins;
    public static int numberOfSpecialCoins;
    public Text coinsText;

    
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
        numberOfSpecialCoins = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }
        coinsText.text = "Score: " + numberOfCoins;
        
        if(SwipeManager.tap)
            {
                isGameStarted = true;
                Destroy(startingText);
            }
        
    }
}
