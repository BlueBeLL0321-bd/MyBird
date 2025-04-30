using UnityEngine;

namespace MyBird
{
    // 타이틀 신을 관리하는 클래스
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";

        // 치트키
        [SerializeField] private bool isCheat = false;
        #endregion

        private void Update()
        {
#if UNITY_EDITOR
            // 치트키
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetSaveData();
            }
#endif
        }


        public void Play()
        {
            fader.FadeTo(loadToScene);
        }

        // 치트키
        void ResetSaveData()
        {
            if (isCheat == false)
                return;

            PlayerPrefs.DeleteAll();
        }
    }
}