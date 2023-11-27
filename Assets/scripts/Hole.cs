using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball ball =  other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            GameManager.instance.PlayerScore += ball.Point;
            GameManager.instance.UpdateScoreText();
            Destroy(ball.gameObject);
        }
    }
}
