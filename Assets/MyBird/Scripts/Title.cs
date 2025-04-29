using UnityEngine;

namespace MyBird
{
    // Ÿ��Ʋ ���� �����ϴ� Ŭ����
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";

        // ġƮŰ
        [SerializeField] private bool isCheat = false;
        #endregion

        private void Update()
        {
            // ġƮŰ
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetSaveData();
            }
        }

        public void Play()
        {
            fader.FadeTo(loadToScene);
        }

        // ġƮŰ
        void ResetSaveData()
        {
            if (isCheat == false)
                return;

            PlayerPrefs.DeleteAll();
        }
    }
}