using System;
using System.Collections;
using UnityEngine;

public class KeySpriteAnimator : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    [SerializeField] private SpriteRenderer sprRenderer;
    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        // Starts The Spin In A New Thread
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        // Sets Index
        int currentIndex = 0;
        // Repeats Constantly (Bad practice to my knowlege but worked for now)
        while (true)
        {
            // If within Range
            if (currentIndex >= sprites.Length) {currentIndex = 0; };
            // Changes The Sprite
            sprRenderer.sprite = sprites[currentIndex];
            // Increase The Index
            currentIndex++;
            // Wait Speed
            yield return new WaitForSeconds(spinSpeed);
        }
    }
}
