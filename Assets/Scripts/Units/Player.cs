using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField]
    private GameEvent _gameOverEvent = null,
        _resourcesUpdateEvent = null;



    private WaveController _controller = null;

    public override int Health
    {
        get
        {
            return _health;
        }
        protected set
        {
            _health = value < 0 ? 0 : value;
            _resourcesUpdateEvent.Raise();
        }
    }

    private void Init()
    {
        Health = _maxHealth;
    }

    public void Restart()
    {
        Init();
    }
    private void Start()
    {
        _controller = FindObjectOfType<WaveController>();
        Init();
    }

    protected override void Die()
    {
        _gameOverEvent.Raise();
    }
}
