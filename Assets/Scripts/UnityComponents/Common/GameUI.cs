using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityComponents.Common
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject _startMenu;
        [SerializeField] private GameObject _endMenu;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _finalScore;
        [SerializeField] private TMP_Text _position;
        [SerializeField] private TMP_Text _rotation;
        [SerializeField] private TMP_Text _velocity;
        [SerializeField] private int _sceneIndex;

        private string _formatScore = "{0:D4}";
        private string _formatFinalScore = "score {0:D4}";
        private string _formatPosition = "({0:F1} ; {1:F1})";
        private string _formatRotation = "{0:F0}°";
        private string _formatVelocity = "{0:F1} */s";

        private void Awake()
        {
            Time.timeScale = 0f;
            _startMenu.SetActive(true);
        }

        public void OnStartGameClick()
        {
            _startMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void OnGameOver()
        {
            _endMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void OnNewGameClick()
        {
            SceneManager.LoadScene(_sceneIndex);
        }

        public void SetScore(int value, bool setToFinal = false)
        {
            if (setToFinal) _finalScore.text = string.Format(_formatFinalScore, value);
            else _score.text = string.Format(_formatScore, value);
        }

        public void SetPosition(Vector2 position)
        {
            _position.text = string.Format(_formatPosition, position.x, position.y);
        }

        public void SetRotation(float rotation)
        {
            _rotation.text = string.Format(_formatRotation, rotation);
        }

        public void SetVelocity(float velocity)
        {
            _velocity.text = string.Format(_formatVelocity, velocity);
        }
    }
}
