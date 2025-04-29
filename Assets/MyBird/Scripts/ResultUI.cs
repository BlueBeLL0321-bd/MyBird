using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyBird
{
    // ���� ��� ���� �ֱ�, ����Ʈ ���ھ�, ���ھ� ���� �ֱ�, �ٽ� �ϱ�, �޴� ���� ��ư ��� ����
    public class ResultUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "Title";

        // Info UI
        public TextMeshProUGUI bestScore;
        public TextMeshProUGUI score;
        public TextMeshProUGUI newText;
        #endregion

        private void OnEnable()
        {
            // GameManager.BestScore�� GameManager.Score ��
            if(GameManager.Score > GameManager.BestScore)
            {
                // �ְ� ���� ����
                GameManager.BestScore = GameManager.Score;
                // ���� ����
                PlayerPrefs.SetInt("bestScore", GameManager.Score);
                newText.text = "NEW";
            }
            else
            {
                newText.text = "";
            }

            bestScore.text = GameManager.BestScore.ToString();
            score.text = GameManager.Score.ToString();
        }

        // �ٽ� �ϱ�
        public void Retry()
        {
            // ���� �� �ٽ� �ҷ�����
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            // Ÿ��Ʋ �� �̵�
            fader.FadeTo(loadToScene);
        }
    }
}

