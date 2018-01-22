using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private ResultController resultController;
        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            
        }

        private void Awake()
        {
            Messenger<int>.AddListener(GameEvent.PLAYER_WIN, newScore);
        }

        private void OnDestroy()
        {
            Messenger<int>.RemoveListener(GameEvent.PLAYER_WIN, newScore);
        }

        private void newScore(int value)
        {
            resultController.SaveScore(value);
        }
    }
}
