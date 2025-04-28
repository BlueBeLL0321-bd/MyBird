using UnityEngine;

namespace MyBird
{
    // 배경 스크롤 구현
    public class GroundMove : MonoBehaviour
    {
        #region Variables
        // 스크롤 이동 속도
        [SerializeField] private float moveSpeed = 5f;
        #endregion

        private void Update()
        {
            // 배경 이동
            Move();
        }

        // 배경을 왼쪽으로 이동시킨다
        // 배경의 x좌표가 -8.4보다 같거나 작으면 x좌표를 제자리로 놓는다
        void Move()
        {
            if (GameManager.IsStart == false)
                return;

            // 왼쪽으로 moveSpeed만큼 이동
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);

            //
            if(transform.localPosition.x <= -8.4f)
            {
                transform.position = new Vector3(transform.position.x + 8.4f, transform.position.y, transform.position.z);
            }
        }
    }
}