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
    
    public static DialougeBehaviour instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    private void Start()
    {
        frameObject.SetActive(false);
    }

    public void CallDisplayText(string newName, string newBody)
    {
        if(newName == string.Empty || newBody == string.Empty) return;
        StartCoroutine(StartWriting(newName, newBody));
    }
    
    IEnumerator StartWriting(string newName, string newBody)
    {
        frameObject.SetActive(true);
        nameText.text = newName;
        bodyText.text = newBody;
        yield return new WaitForSeconds(2f);
        frameObject.SetActive(false);
    }
}
