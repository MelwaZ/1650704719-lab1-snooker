using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int playerScore;
    public int PlayerScore { get; set; }
    [SerializeField] private GameObject ballPrefabs;
    [SerializeField] private GameObject[] ballPositions;

    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballLine;
    [SerializeField] private GameObject camera;
    [SerializeField] private Image TextBG;

    [SerializeField] private float xInput;
    [SerializeField] private float force;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text devText;

    void Start()
    {
        instance = this;

        camera = Camera.main.gameObject;
        CameraBehindBall();
        UpdateScoreText();
        ShowDevText();

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
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StopBall();
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
        cueBall.transform.Rotate(new Vector3(0f, xInput/10, 0f));
    }
    void ShootBall()
    {
        camera.transform.parent = null;
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
        ballLine.SetActive(false);
    }
    void CameraBehindBall()
    {
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(0f, 45f, 0f);
    }
    void StopBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;

        cueBall.transform.eulerAngles = Vector3.zero;
        CameraBehindBall();
        camera.transform.eulerAngles = new Vector3(80f, 0f, 0f);
        ballLine.SetActive(true);
    }

    public void UpdateScoreText()
    {
        TextBG.enabled =true;
        scoreText.text = $"PlayerScore : {PlayerScore}";
    }    
    public void ShowDevText()
    {
        devText.text = $"นายกษิดิ์เดช สุทธิพัฒน์อนันต์ \n No.24 1650704719";
    }
}
