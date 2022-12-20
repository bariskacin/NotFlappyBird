using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsUp : MonoBehaviour
{
    [SerializeField] AudioClip pointsSFX;
    [SerializeField] int pointsForPlayer = 1;

    bool wasPassed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player" && !wasPassed)
        {
            wasPassed = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForPlayer);
            AudioSource.PlayClipAtPoint(pointsSFX, Camera.main.transform.position);
            //Destroy(gameObject);
        } 
    }
}
