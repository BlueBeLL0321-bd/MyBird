using UnityEngine;

namespace MyBird
{
    // 기둥 생성기 - 1초마다 기둥 하나씩 생성
    public class PipeSpawner : MonoBehaviour
    {
        #region Variables
        // 기둥 프리팹
        public GameObject pipePrefab;

        // 1초 타이머
        [SerializeField] private float pipeTimer = 1f;
        private float countdown = 0f;

        // 스폰 위치
        [SerializeField] private float maxSpawnY = 3.3f;
        [SerializeField] private float minSpawnY = -1.6f;

        // 스폰 간격 : 10개씩 통과할 때마다 0.95 ~ 1.05 -> 0.90 ~ 1.00 -> 0.85 ~ 0.95
        [SerializeField] private float maxSpawnTime = 1.05f;
        [SerializeField] private float minSpawnTime = 0.95f;
        [SerializeField] private float levelingTime = 0.05f;
        #endregion

        // 1초마다 기둥 하나씩 생성, 게임 시작 시(IsStart == true)
        private void Update()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;

            // 타이머
            countdown += Time.deltaTime;
            if(countdown >= pipeTimer)
            {
                // 타이머 기능
                SpawnPipe();

                // 타이머 초기화
                countdown = 0f;

                float levelingValue = (int)(GameManager.Score / 10) * levelingTime;
                pipeTimer = Random.Range(minSpawnTime - levelingValue, maxSpawnTime - levelingValue);
            }
        }

        // 기둥 생성
        void SpawnPipe()
        {
            float spawnY = this.transform.position.y + Random.Range(minSpawnY, maxSpawnY);
            Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);
            Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        }
    }
}