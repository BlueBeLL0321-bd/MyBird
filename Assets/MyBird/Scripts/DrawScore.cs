using TMPro;
using UnityEngine;

namespace MyBird
{
    // ���ھ� �ؽ�Ʈ�� �׸���
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

