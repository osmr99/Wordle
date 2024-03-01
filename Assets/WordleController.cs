using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordleController : MonoBehaviour
{
    [SerializeField] TMP_InputField playerInput;
    [SerializeField] TMP_Text playerInputText;
    [SerializeField] Button submitGuess;
    //[SerializeField] TextMeshProUGUI submitGuessText;
    [SerializeField] TMP_Text submitGuessText;
    [SerializeField] WordleModel model;
    [SerializeField] WordleView view;
    List<string> submittedWords = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GameSetup()
    {
        playerInput.text = null;
        playerInputText.color = Color.black;
        submitGuessText.color = Color.black;
        submitGuessText.text = "Submit";
        submitGuessText.fontSize = 24;
        submitGuessText.maxVisibleLines = 1;
    }

    public void SubmitGuess()
    {
        if (playerInput.text.Length == 5)
        {
            bool numbers = false; // Checking for numbers in the 5 characters word
            for(int i = 0; i < playerInput.text.Length; i++)
            {
                if (char.IsDigit(playerInput.text, i) == true)
                {
                    numbers = true; // Found a number
                }
            }
            if (numbers)
            {
                foundNumbers();
                numbers = false;
            }
            else if (submittedWords.Contains(playerInput.text) || submittedWords.Contains(playerInput.text.ToLower())) // Checking if the word has been used already
            {
                playerInputText.color = Color.cyan;
                submitGuessText.fontSize = 18;
                submitGuessText.maxVisibleLines = 2;
                submitGuessText.text = "You already used this word";
            }
            else
            {
                WordleModel.isValidGuess(playerInput.text.ToLower()); // Checking for the guess
                textReset();
                submittedWords.Add(playerInput.text.ToLower());
                Debug.Log("Submitted!" + " " + playerInput.text.ToLower());
                playerInput.text = null;
            }
        }
        else if (playerInput.text != null)
        {
            bool numbers = false; // Checking for numbers to tell the user if they used it.
            for (int i = 0; i < playerInput.text.Length; i++)
            {
                if (char.IsDigit(playerInput.text, i) == true)
                    numbers = true; // Found a number
            }
            if (numbers)
            {
                foundNumbers();
                numbers = false;
            }
            else if(playerInput.text.Length > 0)
            {
                playerInputText.color = Color.red;
                submitGuessText.color = Color.red;
                submitGuessText.fontSize = 20;
                submitGuessText.text = "5 characters pls";
                submitGuessText.maxVisibleLines = 2;
            }
        }
        else
        {
            playerInputText.color = Color.red;
            submitGuessText.fontSize = 22;
            submitGuessText.text = "Make a guess";
        }
    }

    public void textReset()
    {
        playerInputText.color = Color.black;
        submitGuessText.color = Color.black;
        submitGuessText.text = "Submit";
        submitGuessText.fontSize = 24;
        submitGuessText.maxVisibleLines = 1;
    }

    void foundNumbers()
    {
        playerInputText.color = Color.red;
        submitGuessText.color = Color.red;
        submitGuessText.fontSize = 18;
        submitGuessText.text = "No Numbers";
    }

    void WinGame()
    {

    }

    void LoseGame()
    {

    }

}
