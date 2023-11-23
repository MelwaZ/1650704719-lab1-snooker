using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallColors
{
	White,
	Red,
	Yellow,
	Green,
	Brown,
	Blue,
	Pink,
	Black
}

public class Ball : MonoBehaviour
{
    [SerializeField] private int point;
    public int Point { get { return point; } }

    [SerializeField] private BallColors ballColors;

    [SerializeField] private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColorAndPont(BallColors color)
    {
        switch (color)
        {
            case BallColors.White: 
                point = 0;
                _meshRenderer.material.color = Color.white;
                break;            
            case BallColors.Red: 
                point = 1;
                _meshRenderer.material.color = Color.red;
                break;            
            case BallColors.Yellow: 
                point = 2;
                _meshRenderer.material.color = Color.yellow;
                break;            
            case BallColors.Green: 
                point = 3;
                _meshRenderer.material.color = Color.green;
                break;            
            case BallColors.Brown: 
                point = 4;
                _meshRenderer.material.color = new Color32(145,81,9,255);
                break;            
            case BallColors.Blue: 
                point = 5;
                _meshRenderer.material.color = Color.blue;
                break;            
            case BallColors.Pink: 
                point = 6;
                _meshRenderer.material.color = Color.magenta;
                break;                  
            case BallColors.Black: 
                point = 7;
                _meshRenderer.material.color = Color.black;
                break;            
        }
     }
}
