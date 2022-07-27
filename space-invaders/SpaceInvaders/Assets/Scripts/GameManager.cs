using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameStateManager game;
    private Player _player;
    private Invaders _invaders;
    private RedInvader _redInvader;
    private Shield[] _shields;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

    public int score { get; private set; }
    public int lives { get; private set; }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _invaders = FindObjectOfType<Invaders>();
        _redInvader = FindObjectOfType<RedInvader>();
        _shields = FindObjectsOfType<Shield>();
    }

    private void Start()
    {
        _player.killed += OnPlayerKilled;
        _redInvader.killed += OnRedInvaderKilled;
        _invaders.killed += OnInvaderKilled;
        NewGame();            
    }

    private void Update()
    {
        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return))
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        _invaders.ResetInvaders();
        _invaders.gameObject.SetActive(true);

        for (int i = 0; i < _shields.Length; i++)
        {
            _shields[i].gameObject.SetActive(true);
        }

        Respawn();
    }

    private void Respawn()
    {
        Vector3 position = _player.transform.position;
        position.x = 0f;
        _player.transform.position = position;
        _player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        _invaders.gameObject.SetActive(false);
        game.SwitchState(new GameEndState());
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(4, '0');
    }

    private void SetLives(int lives)
    {
        this.lives = Mathf.Max(lives, 0);
        livesText.text = lives.ToString();
    }

    private void OnPlayerKilled()
    {
        SetLives(lives - 1);

        _player.gameObject.SetActive(false);

        if (lives > 0)
        {
            Invoke(nameof(NewRound), 1f);
        }
        else
        {
            GameOver();
        }
    }

    private void OnInvaderKilled(Invader invader)
    {
        SetScore(score + invader.score);

        if (_invaders.amountKilled == _invaders.totalInvaders)
        {
            NewRound();
        }
    }

    private void OnRedInvaderKilled(RedInvader redInvader)
    {
        SetScore(score + redInvader.score);
    }

}