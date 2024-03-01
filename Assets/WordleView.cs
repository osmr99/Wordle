using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordleView : MonoBehaviour
{

    [SerializeField] GameObject[] rows = new GameObject[6];
    [SerializeField] GameObject view;
    //GameObject currentRow;
    //GameObject theCell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup()
    {
        // Sets all text back to normal
        WordleController.staticPlayerInputText.color = Color.black;
        WordleController.staticSubmitGuessText.color = Color.black;
        WordleController.staticSubmitGuessText.text = "Submit";
        WordleController.staticSubmitGuessText.fontSize = 24;
        WordleController.staticSubmitGuessText.maxVisibleLines = 1;
        // Sets all cells to white
        for (int i = 0; i < 6; i++)
        {
            GameObject currentRow = rows[i];
            //Debug.Log("Ok");
            for (int j = 0; j < 5; j++)
            {
                Image currentCell = currentRow.transform.GetChild(j).GetComponent<Image>();
                currentCell.color = Color.white;
                //Debug.Log("Nice");
            }
        }
    }

    void UpdateView()
    {

    }

    public void resetGame()
    {
        Setup();
    }

    static public void emptyText()
    {
        WordleController.staticPlayerInput.text = null;
    }

    static public void alreadyUsed()
    {
        WordleController.staticPlayerInputText.color = Color.cyan;
        WordleController.staticSubmitGuessText.fontSize = 18;
        WordleController.staticSubmitGuessText.maxVisibleLines = 2;
        WordleController.staticSubmitGuessText.text = "You already used this word";

    }

    static public void notValid()
    {
        WordleController.staticPlayerInputText.color = Color.red;
        WordleController.staticSubmitGuessText.color = Color.red;
        WordleController.staticSubmitGuessText.fontSize = 20;
        WordleController.staticSubmitGuessText.maxVisibleLines = 2;
        WordleController.staticSubmitGuessText.text = "Not a valid word";
    }

    static public void fiveCharsPls()
    {
        WordleController.staticPlayerInputText.color = Color.red;
        WordleController.staticSubmitGuessText.color = Color.red;
        WordleController.staticSubmitGuessText.fontSize = 20;
        WordleController.staticSubmitGuessText.text = "5 characters pls";
        WordleController.staticSubmitGuessText.maxVisibleLines = 2;
    }

    static public void textReset()
    {
        WordleController.staticPlayerInputText.color = Color.black;
        WordleController.staticSubmitGuessText.color = Color.black;
        WordleController.staticSubmitGuessText.text = "Submit";
        WordleController.staticSubmitGuessText.fontSize = 24;
        WordleController.staticSubmitGuessText.maxVisibleLines = 1;
    }

    static public void foundNumbers()
    {
        WordleController.staticPlayerInputText.color = Color.red;
        WordleController.staticSubmitGuessText.color = Color.red;
        WordleController.staticSubmitGuessText.fontSize = 18;
        WordleController.staticSubmitGuessText.text = "No Numbers";
    }

    static public void viewLoseGame()
    {
        WordleController.staticPlayerInput.text = "<b>" + WordleController.staticPlayerInput.text + "</b>";
        WordleController.staticSubmitGuessText.color = Color.red;
        WordleController.staticSubmitGuessText.fontSize = 16;
        WordleController.staticSubmitGuessText.maxVisibleLines = 2;
        WordleController.staticSubmitGuessText.text = "<b>The word was " + WordleModel.correctAnswer + "</b>";
    }

}
