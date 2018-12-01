using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakClip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int maxHits;
    [SerializeField] int hits = 0;
    

    //AudioSource myAudioSource;

    Level level;
    GameStatus gameStatus;



    void Start()
    {
        maxHits = hitSprites.Length + 1;
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            gameStatus = FindObjectOfType<GameStatus>();
            level.addBreakableBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            hits++;

            if (hits >= maxHits)
            {
                destroyBlock();
                gameStatus.addScore();
                triggerSparkleVFX();
            }
            else
            {
                showNextHitSprite();
            }
        }
        

    }

    private void showNextHitSprite()
    {
        int spriteIndex = hits - 1;
        if(spriteIndex > hitSprites.Length-1)
        {
            spriteIndex = hitSprites.Length - 1;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void destroyBlock()
    {

        AudioSource.PlayClipAtPoint(blockBreakClip, Camera.main.transform.position);
        level.removeBreakableBlock();
        Destroy(gameObject);
    }

    private void triggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(sparkles, 1f);
    }
}
