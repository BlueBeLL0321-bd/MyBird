using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyBird
{
    // 게임 결과 보여 주기, 베스트 스코어, 스코어 보여 주기, 다시 하기, 메뉴 가기 버튼 기능 구현
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
            // GameManager.BestScore와 GameManager.Score 비교
            if(GameManager.Score > GameManager.BestScore)
            {
                // 최고 점수 갱신
                GameManager.BestScore = GameManager.Score;
                // 파일 저장
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

        // 다시 하기
        public void Retry()
        {
            // 현재 신 다시 불러오기
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            // 타이틀 신 이동
            fader.FadeTo(loadToScene);
        }
    }
}

