using System;
using UnityEngine;
using UnityEngine.Events;

public class InteractionDialougeBehaviour : MonoBehaviour
{
    [Header("Dialouge Trext")]
    [SerializeField] private string[] nameText;
    [SerializeField] private string[] bodyText;
    
    private void OnCollisionEnter2D(Collision2D colRef) 
    {
        if (colRef.gameObject.TryGetComponent(out  SimplePlayerMovement _))
        {
            DialougeBehaviour.instance.CallDisplayText(nameText, bodyText); 
        }
        else
        {
            Debug.Log(colRef.gameObject.name);
        }
    }
}