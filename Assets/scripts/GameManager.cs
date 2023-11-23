using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefabs;
    [SerializeField] private GameObject[] ballPositions;

    [SerializeField] private GameObject cuvBall;
    [SerializeField] private GameObject ballLine;

    [SerializeField] private float xInput;
    [SerializeField] private float force;

    void Start()
    {
        instance = this;

        SetBalls(BallColors.White,0);
        SetBalls(BallColors.Red, 1);
        SetBalls(BallColors.Yellow, 2);
        SetBalls(BallColors.Green, 3);
        SetBalls(BallColors.Brown, 4);
        SetBalls(BallColors.Blue, 5);
        SetBalls(BallColors.Pink, 6);
        SetBalls(BallColors.Black, 7);
    }
    void Update()
    {
        RotateBall();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }
    }

    void SetBalls(BallColors color,int pos)
    {
        GameObject ball =  Instantiate(ballPrefabs,ballPositions[pos].transform.position,Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        b.SetColorAndPont(color);
    }
    void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cuvBall.transform.Rotate(new Vector3(0f, xInput/10, 0f));
    }
    void ShootBall()
    {
        Rigidbody rd = cuvBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
        ballLine.SetActive(false);
    }
}
