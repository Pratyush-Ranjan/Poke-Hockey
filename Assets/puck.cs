using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puck : MonoBehaviour
{

    public scorescript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    public float maxspeed;
    public AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "aigoal")
            {
                ScoreScriptInstance.Increment(scorescript.Score.PlayerScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "playergoal")
            {
                ScoreScriptInstance.Increment(scorescript.Score.AiScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(true));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlayPuckCollision();
    }

    private IEnumerator ResetPuck(bool didAiScore)
    {
        yield return new WaitForSecondsRealtime(2);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
        if (didAiScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);
    }
    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }
    private void fixedupdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxspeed);
    }

}
