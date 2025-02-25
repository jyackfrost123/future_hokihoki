using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpningPlayerAnimationController : MonoBehaviour
{

    [SerializeField]
    private Sprite[] walkSprites;

    [SerializeField]
    private SpriteRenderer playerSprite;

    [SerializeField]
    private float speed = 0.1f;

    [SerializeField]
    private float baseFlameTime = 0.3f;

    private float time;

    private int spriteNum = 0;



    
    void Start()
    {
        time = baseFlameTime;
        spriteNum = 0;

        playerSprite.sprite = walkSprites[spriteNum];
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        time -= Time.deltaTime;
        if(time <= 0) {
            spriteNum++;
            if(spriteNum > walkSprites.Length - 1) {
                spriteNum = 0;
            }
            playerSprite.sprite = walkSprites[spriteNum];

            time = baseFlameTime;

        }
    }
}
