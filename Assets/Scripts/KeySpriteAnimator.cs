using System;
using System.Collections;
using UnityEngine;

public class KeySpriteAnimator : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        int currentIndex = 0;
        while (true)
        {
            if (currentIndex >= sprites.Length) {currentIndex = 0; };
            renderer.sprite = sprites[currentIndex];
            currentIndex++;
            yield return new WaitForSeconds(spinSpeed);
        }
    }
}
