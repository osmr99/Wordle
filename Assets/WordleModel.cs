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

    static public int currentAttempt = 1;
    public Cells[,] cells = new Cells[6, 5];
    [SerializeField] TextAsset possibleAnswersAsset;
    [SerializeField] TextAsset allowedWordsAsset;
    static string[] possibleAnswers;
    static public string[] allowedWords;
    static public string correctAnswer;
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

    public static bool isValidGuess(string s)
    {
        if(s == correctAnswer)
            return true;
        return false;
    }

    void UpdateCells()
    {

    }

    public void resetGame()
    {
        Setup();
    }
}
