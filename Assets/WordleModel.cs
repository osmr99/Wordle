using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WordleModel : MonoBehaviour
{

    public int currentAttempt = 0;
    public char[,] cells;
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

    [ContextMenu("Test")]
    void Setup()
    {
        possibleAnswers = possibleAnswersAsset.ToString().Split("\n");
        allowedWords = allowedWordsAsset.ToString().Split("\n");
        correctAnswer = allowedWords[UnityEngine.Random.Range(0, allowedWords.Length)];
        Debug.Log(correctAnswer);
    }

    static bool isValidGuess(string s)
    {
        return false;
    }

    void UpdateCells()
    {

    }
}
