using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Cells
{
    public int cellsRows;
    public int cellsColumns;

    public Cells(int r, int c)
    {
        cellsRows = r;
        cellsColumns = c;
    }
}

public class WordleModel : MonoBehaviour
{

    public int currentAttempt = 0;
    public Cells[,] cells = new Cells[6, 5];
    [SerializeField] TextAsset possibleAnswersAsset;
    [SerializeField] TextAsset allowedWordsAsset;
    string[] possibleAnswers;
    string[] allowedWords;
    string correctAnswer;
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
        correctAnswer = allowedWords[UnityEngine.Random.Range(0, possibleAnswers.Length)];
        //Debug.Log(correctAnswer);
    }

    public static bool isValidGuess(string s)
    {
        return false;
    }

    void UpdateCells()
    {

    }
}
