using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cells
{
    public char letter;
    public Color color;

    public Cells(char l, Color c)
    {
        letter = l;
        color = c;
    }
}

public class WordleModel : MonoBehaviour
{

    public int currentAttempt;
    public Cells[,] cells = new Cells[6,5];
    [SerializeField] TextAsset possibleAnswersAsset;
    [SerializeField] TextAsset allowedWordsAsset;
    public string[] possibleAnswers;
    public string[] allowedWords;
    public string correctAnswer;
    [SerializeField] WordleView view;
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

    //[ContextMenu("Test")]
    void Setup()
    {
        possibleAnswers = possibleAnswersAsset.ToString().Split("\n");
        allowedWords = allowedWordsAsset.ToString().Split("\n");
        correctAnswer = allowedWords[UnityEngine.Random.Range(0, possibleAnswers.Length)].Trim();
        Debug.Log(correctAnswer);
    }

    public bool isValidGuess(string s)
    {
        if(s == correctAnswer)
            return true;
        return false;
    }

    public void UpdateCells()
    {
        // Setting up letters
        int temp = currentAttempt - 2;
        string theWord = controller.playerInput.text;
        //Debug.Log(theWord[0]);
        //Debug.Log(theWord[1]);
        //Debug.Log(theWord[2]);
        //Debug.Log(theWord[3]);
        //Debug.Log(theWord[4]);
        //GameObject theCurrentRow = view.rows[temp];
        //char currentChar;
        GameObject currentRow = view.rows[temp];
        for (int i = 0; i < 5; i++)
        {
            string currentChar = theWord[i].ToString();
            TMP_Text wordChar = currentRow.transform.GetChild(i).GetComponentInChildren<TMP_Text>();
            wordChar.text = currentChar;
            Debug.Log(wordChar.text);
            //Image currentCell = currentRow.transform.GetChild(j).GetComponent<Image>();
            //currentCell.color = Color.white;
        }
    }

    /*for (int i = 0; i < 6; i++)
        {
            GameObject currentRow = rows[i];
            //Debug.Log("Ok");
            for (int j = 0; j < 5; j++)
            {
                Image currentCell = currentRow.transform.GetChild(j).GetComponent<Image>();
                currentCell.color = Color.white;
                //Debug.Log("Nice");
            }
        }*/


    public void resetGame()
    {
        Setup();
    }
}
