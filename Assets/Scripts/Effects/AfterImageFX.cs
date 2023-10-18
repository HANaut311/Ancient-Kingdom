using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageFX : MonoBehaviour
{
    private SpriteRenderer sr;
    private float colorLosseRate;


    public void SetupAfterImage(float _lossingSpeed, Sprite _spriteImage)
    {
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = _spriteImage;

        colorLosseRate = _lossingSpeed;

    }

    private void Update()
    {
        float alpha = sr.color.a - colorLosseRate * Time.deltaTime;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);    

        if(sr.color.a <= 0 )
            Destroy(gameObject);
    }

}
