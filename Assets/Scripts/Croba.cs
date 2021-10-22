using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Croba : MonoBehaviour
{
    public int initialSize;

    private List<Transform> _rabeta = new List<Transform>();
    public Transform rabetaPrefab;

    public Text txtScore;
    public Text txtHighScore;
    private int score;
    private int highScore;

    private Vector2 _direction = Vector2.up;
    public Joystick joystick;

    public BoxCollider2D Grid;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (joystick.Horizontal >= .6f)
        {
            _direction = Vector2.right;
        }
        else if (joystick.Horizontal <= -.6f)
        {
            _direction = Vector2.left;
        }
        else if (joystick.Vertical >= .6f)
        {
            _direction = Vector2.up;
        }
        else if (joystick.Vertical <= -.6f)
        {
            _direction = Vector2.down;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _rabeta.Count -1; i > 0; i--){
            _rabeta[i].position = _rabeta[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );


    }

    private void Grow()
    {
        Transform rabeta = Instantiate(this.rabetaPrefab);
        rabeta.position = _rabeta[_rabeta.Count - 1].position;

        _rabeta.Add(rabeta);

        score += 10;
        txtScore.text = "Score: " + score.ToString();

        
    }

    private void Reset()
    {

        for (int i = 1; i < _rabeta.Count; i++) { Destroy(_rabeta[i].gameObject); }

        _rabeta.Clear();
        _rabeta.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++) { _rabeta.Add(Instantiate(this.rabetaPrefab)); }

        this.transform.position = Vector3.zero;

        if (score > highScore)
        {
            highScore = score;
            txtHighScore.text = "Highest Score: " + highScore.ToString();
        }

        score = 0;
        txtScore.text = "Score: " + score.ToString();

        
    }
    private void OnTriggerEnter2D(Collider2D Treta)
    {
        if (Treta.tag == "Comida")
        {
            Grow();
        } else if (Treta.tag == "Obstacle") { Reset();}

    }
}
