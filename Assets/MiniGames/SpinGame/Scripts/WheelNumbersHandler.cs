using DG.Tweening;
using Global.Utilities;
using SpinGame.Gameplay.Object;
using SpinGame.Utilities;
using UnityEngine;

public class WheelNumbersHandler : MonoBehaviour, ISubscribable
{
    [SerializeField] private Transform layoutParent;
    [SerializeField] private WheelNumber wheelNumberPrefab;

    private void Start()
    {
        Initialize(30);
    }
    
    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Initialize(int wheelCount)
    {
        for (var i = 1; i < wheelCount + 1; i++)
        {
            var type = WheelNumber.Type.Green;
            if (i % 30 == 0 && i > 0)
            {
                type = WheelNumber.Type.White;
            }
            else if (i % 5 == 0 && i > 0)
            {
                type = WheelNumber.Type.Blue;
            }
            
            var wheelNumber = Instantiate(wheelNumberPrefab, layoutParent);
            wheelNumber.Initialize(type, i);
        }
    }

    private void MoveLayoutParent()
    {
        layoutParent.transform.DOLocalMoveX(layoutParent.transform.localPosition.x -Constants.DistanceBetweenWheelNumbers, .2f);
    }
    
    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.PostSpinActionEndStarted)
        {
            MoveLayoutParent();
        }
    }

    public void Subscribe()
    {
        Signals.GameStateChanged += OnGameStateChanged;
    }

    public void Unsubscribe()
    {
        Signals.GameStateChanged -= OnGameStateChanged;
    }
}