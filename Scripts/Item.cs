using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        gameObject.layer = 8;
        spriteRenderer.color = Color.white;
        Invoke("OnActive", 1f);
    }
    void OnActive()
    {
        //#.Set Landing Floor
        int ran = Random.Range(0, 3);
        gameObject.layer = 12 + ran;

        //#.Disable Animation
        spriteRenderer.DOColor(new Color(1,1,1,0.5f),0f).SetDelay(3f);
        spriteRenderer.DOColor(new Color(1,1,1,0.2f),0f).SetDelay(3.1f);
        spriteRenderer.DOColor(new Color(1,1,1,0.5f),0f).SetDelay(3.2f);
        spriteRenderer.DOColor(new Color(1,1,1,0.2f),0f).SetDelay(3.3f);
        spriteRenderer.DOColor(new Color(1, 1, 1, 0.5f), 0f).SetDelay(3.4f);
        spriteRenderer.DOColor(new Color(1, 1, 1, 0.2f), 0f).SetDelay(3.5f);
        spriteRenderer.DOColor(new Color(1, 1, 1, 0.5f), 0f).SetDelay(3.6f);
        spriteRenderer.DOColor(new Color(1, 1, 1, 0.2f), 0f).SetDelay(3.7f);

        //#.Self Disable
        Invoke("SelfDisable", 3.8f);
    }

    void SelfDisable()
    {
        gameObject.SetActive(false);
    }
}
