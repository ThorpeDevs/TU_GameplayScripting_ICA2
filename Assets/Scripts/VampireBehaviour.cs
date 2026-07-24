using System;
using UnityEngine;
using UnityEngine.Events;

public class VampireBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UnityEvent startCutscene;

    [Header("Dialouge")] 
    [SerializeField] private string[] bossName;
    [SerializeField] private string[] bossBody; 
    
    private Animator sprAnimator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out  SimplePlayerMovement _))
        {
            startCutscene.Invoke();
            DialougeBehaviour.instance.CallDisplayText(bossName, bossBody);
        }
    }
}
