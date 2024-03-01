using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordleController : MonoBehaviour
{
    [SerializeField] public TMP_InputField playerInput;
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
        WordleModel.currentAttempt = 1;
        submitGuess.enabled = true;
        playerInput.enabled = true;
        playerInput.text = null;
        playerInputText.color = Color.black;
        submitGuessText.color = Color.black;
        submitGuessText.text = "Submit";
        submitGuessText.fontSize = 24;
        submitGuessText.maxVisibleLines = 1;
        submittedWords = new List<string>();
    }

    public void SubmitGuess()
    {
        if (playerInput.text.Length == 5)
        {
            bool numbers = false; 
            bool allowedWord = false;
            for(int i = 0; i < playerInput.text.Length; i++) // Checking for numbers in the 5 characters word
            {
                if (char.IsDigit(playerInput.text, i) == true)
                {
                    numbers = true; // Found a number
                }
            }
            if (numbers)
            {
                foundNumbers();
            }
            else if (numbers == false) // No numbers found
            {
                bool usedWord = false;
                if (submittedWords.Contains(playerInput.text) || submittedWords.Contains(playerInput.text.ToLower())) // Checking if the word has been used already
                {
                    usedWord = true;
                    playerInputText.color = Color.cyan;
                    submitGuessText.fontSize = 18;
                    submitGuessText.maxVisibleLines = 2;
                    submitGuessText.text = "You already used this word";
                }
                if (usedWord == false)
                {
                    for (int i = 0; i < WordleModel.allowedWords.Length; i++) // Checking if the word exists from the allowed words.txt
                    {
                        if (playerInput.text == WordleModel.allowedWords[i].Trim())
                        {
                            allowedWord = true;
                            i = WordleModel.allowedWords.Length; // When it finds the word,this will end the loop
                        }
                    }
                    if (allowedWord) // The guess is valid, now it will check with the real answer
                    {
                        bool result = false;
                        result = WordleModel.isValidGuess(playerInput.text.ToLower()); // Checking for the guess
                        WordleModel.currentAttempt++;
                        submittedWords.Add(playerInput.text.ToLower());
                        Debug.Log("Submitted" + " " + playerInput.text.ToLower());
                        if (result)
                            WinGame();
                        else if (WordleModel.currentAttempt > 6)
                            LoseGame();
                        else
                            playerInput.text = null;
                    }
                    else // The word is not valid
                    {
                        playerInputText.color = Color.red;
                        submitGuessText.color = Color.red;
                        submitGuessText.fontSize = 20;
                        submitGuessText.maxVisibleLines = 2;
                        submitGuessText.text = "Not a valid word";
                    }
                }
            }
        }
        else if (playerInput.text != null) // 'If the word is less than 5 characters but more than 0 then...'
        {
            bool numbers = false; // Checking for numbers to tell the user to not used them
            for (int i = 0; i < playerInput.text.Length; i++)
            {
                if (char.IsDigit(playerInput.text, i) == true)
                    numbers = true; // Found a number
            }
            if (numbers)
            {
                foundNumbers();
            }
            else if(playerInput.text.Length > 0 && playerInput.text.Length < 5)
            {
                playerInputText.color = Color.red;
                submitGuessText.color = Color.red;
                submitGuessText.fontSize = 20;
                submitGuessText.text = "5 characters pls";
                submitGuessText.maxVisibleLines = 2;
            }
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
        playerInput.enabled = false;
        submitGuess.enabled = false;
        playerInput.text = "<b>" + playerInput.text + "</b>";
        submitGuessText.color = Color.green;
        WordleModel.currentAttempt--;
        if (WordleModel.currentAttempt == 1)
        {
            submitGuessText.fontSize = 29;
            submitGuessText.text = "HOW?!?";
        }
        else if (WordleModel.currentAttempt == 2)
        {
            submitGuessText.fontSize = 20;
            submitGuessText.text = "Outstanding!";
        }
        else if (WordleModel.currentAttempt == 3)
        {
            submitGuessText.fontSize = 25;
            submitGuessText.text = "Very good";
        }
        else if (WordleModel.currentAttempt == 4)
        {
            submitGuessText.fontSize = 25;
            submitGuessText.text = "You got it!";
        }
        else if (WordleModel.currentAttempt == 5)
        {
            submitGuessText.fontSize = 32;
            submitGuessText.text = "Alright";
        }
        else if (WordleModel.currentAttempt == 6)
        {
            submitGuessText.fontSize = 34;
            submitGuessText.text = "PHEW";
        }
    }

    void LoseGame()
    {
        playerInput.enabled = false;
        submitGuess.enabled = false;
        playerInput.text = "<b>" + playerInput.text + "</b>";
        submitGuessText.color = Color.red;
        submitGuessText.fontSize = 16;
        submitGuessText.maxVisibleLines = 2;
        submitGuessText.text = "<b>The word was " + WordleModel.correctAnswer + "</b>";
    }

    public void resetGame()
    {
        GameSetup();
    }

}
