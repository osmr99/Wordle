using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordleController : MonoBehaviour
{
    [SerializeField] public TMP_InputField playerInput;
    [SerializeField] public TMP_Text playerInputText;
    [SerializeField] Button submitGuess;
    [SerializeField] public TMP_Text submitGuessText;
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
        model.currentAttempt = 1;
        submitGuess.enabled = true;
        playerInput.enabled = true;
        view.emptyText();
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
                view.foundNumbers();
            }
            else if (numbers == false) // No numbers found
            {
                bool usedWord = false;
                if (submittedWords.Contains(playerInput.text) || submittedWords.Contains(playerInput.text.ToLower())) // Checking if the word has been used already
                {
                    usedWord = true;
                    view.alreadyUsed();
                }
                if (usedWord == false)
                {
                    for (int i = 0; i < model.allowedWords.Length; i++) // Checking if the word exists from the allowed words.txt
                    {
                        if (playerInput.text == model.allowedWords[i].Trim())
                        {
                            allowedWord = true;
                            i = model.allowedWords.Length; // When it finds the word,this will end the loop
                        }
                    }
                    if (allowedWord) // The guess is valid, now it will check with the real answer
                    {
                        bool result = false;
                        result = model.isValidGuess(playerInput.text.ToLower()); // Checking for the guess
                        model.currentAttempt++;
                        submittedWords.Add(playerInput.text.ToLower());
                        Debug.Log("Submitted" + " " + playerInput.text.ToLower());
                        model.UpdateCells();
                        if (result)
                            WinGame();
                        else if (model.currentAttempt > 6)
                            LoseGame();
                        else
                            view.emptyText();
                    }
                    else // The word is not valid
                    {
                        view.notValid();
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
                view.foundNumbers();
            }
            else if(playerInput.text.Length > 0 && playerInput.text.Length < 5)
            {
                view.fiveCharsPls();
            }
        }
    }

    void WinGame()
    {
        playerInput.enabled = false;
        submitGuess.enabled = false;
        view.viewWinGame();
    }

    void LoseGame()
    {
        playerInput.enabled = false;
        submitGuess.enabled = false;
        view.viewLoseGame();
    }

    public void resetGame()
    {
        GameSetup();
    }

}
