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
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject currentRow = rows[i];
            Debug.Log("Ok");
            for (int j = 0; j < 5; j++)
            {
                Image currentCell = currentRow.transform.GetChild(j).GetComponent<Image>();
                currentCell.color = Color.white;
                Debug.Log("Nice");
            }
        }
    }

}
