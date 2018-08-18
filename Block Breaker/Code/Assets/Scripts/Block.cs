using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;
    GameStatus gameStatus;

    // state params
    [SerializeField] int timesHit;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            TimesHit();
        }
    }

    private void TimesHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else {
            showNextSprite();
        }
    }

    private void showNextSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();

        TriggerBlockSparkles();
        gameStatus.addToScore();
        Destroy(gameObject, .1f);
    }

    public void TriggerBlockSparkles()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
