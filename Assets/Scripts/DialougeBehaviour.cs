using System;
using TMPro;
using System.Collections;
using UnityEngine;

public class DialougeBehaviour : MonoBehaviour
{
    [Header("Required References")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private GameObject frameObject;
    
    // Allows All Scripts To Fire Public Functions
    // Not Fully Sure How it Works Was Suggested By A Friend
    public static DialougeBehaviour instance; 

    private void Awake()
    {
        // Instance Null Check
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    private void Start()
    {
        // Incase I Or Anyone Else Is Working On UI And Forgets To hide Frame
        frameObject.SetActive(false);
    }

    public void CallDisplayText(string[] newName, string[] newBody)
    {
        // If No Text Return Rather Than Display Empty Text
        if(newName[0] == string.Empty || newBody[0] == string.Empty) return;
        // Start Writing In A New Thread
        StartCoroutine(StartWriting(newName, newBody));
    }
    
    IEnumerator StartWriting(string[] newName, string[] newBody)
    {
        // Show Dialouge Frame
        frameObject.SetActive(true);
        int LastNameIndex = 0;
        // Assign Text
        for (int i = 0; newBody.Length > i; i++)
        {
            // Sets Name
            nameText.text = newName[i];
            
            // Sets Text To Empty
            bodyText.text = "";
            
            for (int c = 0; c < newBody[i].ToCharArray().Length; c++)
            {
                // Types Each Character Individually
                bodyText.text = bodyText.text + newBody[i].ToCharArray()[c];
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2f);
        }
        // Hides The Dialouge Menu
        frameObject.SetActive(false);
    }
}
