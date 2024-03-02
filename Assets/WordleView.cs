using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordleView : MonoBehaviour
{

    [SerializeField] public GameObject[] rows = new GameObject[6];
    [SerializeField] GameObject view;
    [SerializeField] WordleModel model;
    [SerializeField] WordleController controller;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup()
    {
        // Sets all text back to normal
        controller.playerInputText.color = Color.black;
        controller.submitGuessText.color = Color.black;
        controller.submitGuessText.text = "Submit";
        controller.submitGuessText.fontSize = 24;
        controller.submitGuessText.maxVisibleLines = 1;

        // Sets all cells to white
        for (int i = 0; i < 6; i++)
        {
            GameObject currentRow = rows[i];
            for (int j = 0; j < 5; j++)
            {
                Image currentCell = currentRow.transform.GetChild(j).GetComponent<Image>();
                currentCell.color = Color.white;
            }
        }
        // Sets all chars to blanks
        for (int i = 0; i < 6; i++)
        {
            GameObject currentRow = rows[i];
            for (int j = 0; j < 5; j++)
            {
                TMP_Text wordChar = currentRow.transform.GetChild(j).GetComponentInChildren<TMP_Text>();
                wordChar.text = "__";
            }
        }
    }


    public void UpdateView(int color)
    {
        Image currentCell = model.wordChar.transform.GetComponentInParent<Image>();
        if (color == 1)
            currentCell.color = Color.green;
        else if (color == 2)
            currentCell.color = Color.yellow;
        else if (color == 3)
            currentCell.color = Color.gray;
    }

    public void resetGame()
    {
        Setup();
    }

    public void emptyText()
    {
        controller.playerInput.text = null;
    }

    public void alreadyUsed()
    {
        controller.playerInputText.color = Color.cyan;
        controller.submitGuessText.fontSize = 18;
        controller.submitGuessText.maxVisibleLines = 2;
        controller.submitGuessText.text = "You already used this word";

    }

    public void notValid()
    {
        controller.playerInputText.color = Color.red;
        controller.submitGuessText.color = Color.red;
        controller.submitGuessText.fontSize = 20;
        controller.submitGuessText.maxVisibleLines = 2;
        controller.submitGuessText.text = "Not a valid word";
    }

    public void fiveCharsPls()
    {
        controller.playerInputText.color = Color.red;
        controller.submitGuessText.color = Color.red;
        controller.submitGuessText.fontSize = 20;
        controller.submitGuessText.text = "5 characters pls";
        controller.submitGuessText.maxVisibleLines = 2;
    }

    public void textReset()
    {
        controller.playerInputText.color = Color.black;
        controller.submitGuessText.color = Color.black;
        controller.submitGuessText.text = "Submit";
        controller.submitGuessText.fontSize = 24;
        controller.submitGuessText.maxVisibleLines = 1;
    }

    public void foundNumbers()
    {
        controller.playerInputText.color = Color.red;
        controller.submitGuessText.color = Color.red;
        controller.submitGuessText.fontSize = 18;
        controller.submitGuessText.text = "No Numbers";
    }

    public void viewLoseGame()
    {
        controller.playerInput.text = "<b>" + controller.playerInput.text + "</b>";
        controller.submitGuessText.color = Color.red;
        controller.submitGuessText.fontSize = 16;
        controller.submitGuessText.maxVisibleLines = 2;
        controller.submitGuessText.text = "<b>The word was " + model.correctAnswer + "</b>";
    }

    public void viewWinGame()
    {
        controller.playerInput.text = "<b>" + controller.playerInput.text + "</b>";
        controller.submitGuessText.color = Color.green;
        model.currentAttempt--;
        if (model.currentAttempt == 1)
        {
            controller.submitGuessText.fontSize = 29;
            controller.submitGuessText.text = "HOW?!?";
        }
        else if (model.currentAttempt == 2)
        {
            controller.submitGuessText.fontSize = 20;
            controller.submitGuessText.text = "Outstanding!";
        }
        else if (model.currentAttempt == 3)
        {
            controller.submitGuessText.fontSize = 25;
            controller.submitGuessText.text = "Very good";
        }
        else if (model.currentAttempt == 4)
        {
            controller.submitGuessText.fontSize = 25;
            controller.submitGuessText.text = "You got it!";
        }
        else if (model.currentAttempt == 5)
        {
            controller.submitGuessText.fontSize = 32;
            controller.submitGuessText.text = "Alright";
        }
        else if (model.currentAttempt == 6)
        {
            controller.submitGuessText.fontSize = 34;
            controller.submitGuessText.text = "PHEW";
        }
    }

}
