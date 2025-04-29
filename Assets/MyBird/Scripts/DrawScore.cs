using TMPro;
using UnityEngine;

namespace MyBird
{
    // 스코어 텍스트를 그린다
    public class DrawScore : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI scoreText;
        #endregion

        // Update is called once per frame
        void Update()
        {
            scoreText.text = GameManager.Score.ToString();
        }
    }
}

