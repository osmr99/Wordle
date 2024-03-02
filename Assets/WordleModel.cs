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
    public TMP_Text wordChar;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup()
    {
        possibleAnswers = possibleAnswersAsset.ToString().Split("\n");
        allowedWords = allowedWordsAsset.ToString().Split("\n");
        correctAnswer = possibleAnswers[UnityEngine.Random.Range(0, possibleAnswers.Length)].Trim();
    }

    public bool isValidGuess(string s)
    {
        if(s == correctAnswer)
            return true;
        return false;
    }

    public void UpdateCells() // The method for checking if the string matches with the answers and also manages the cells colors.
    {
        int temp = currentAttempt - 2;
        string theWord = controller.playerInput.text;
        GameObject currentRow = view.rows[temp];
        for (int i = 0; i < 5; i++)
        {
            string currentChar = theWord[i].ToString();
            wordChar = currentRow.transform.GetChild(i).GetComponentInChildren<TMP_Text>();
            wordChar.text = currentChar;
            for(int j = 0; j < correctAnswer.Length; j++)
            {
                bool found = false;
                if (theWord[i] == correctAnswer[i])
                {
                    view.UpdateView(1); // Correct letter and position!
                    found = true;
                } 
                else if (theWord[i] != correctAnswer[i])
                {
                    bool existent = false;
                    for(int k = 0; k < correctAnswer.Length; k++)
                    {
                        if (theWord[i] == correctAnswer[k] && found == true)
                        {
                            view.UpdateView(1); // Found a repeated letter in the right position
                            existent = true;
                        }

                        else if (theWord[i] == correctAnswer[k] && found == false)
                        {
                            view.UpdateView(2); // Correct letter but incorrect position
                            existent = true;
                        }
                    }
                    if(existent == false)
                        view.UpdateView(3); // Non existent letter
                }

            }
        }
    }
    public void resetGame()
    {
        Setup();
    }
}
