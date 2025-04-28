using UnityEngine;

namespace MyBird
{
    // ��� ��ũ�� ����
    public class GroundMove : MonoBehaviour
    {
        #region Variables
        // ��ũ�� �̵� �ӵ�
        [SerializeField] private float moveSpeed = 5f;
        #endregion

        private void Update()
        {
            // ��� �̵�
            Move();
        }

        // ����� �������� �̵���Ų��
        // ����� x��ǥ�� -8.4���� ���ų� ������ x��ǥ�� ���ڸ��� ���´�
        void Move()
        {
            if (GameManager.IsStart == false)
                return;

            // �������� moveSpeed��ŭ �̵�
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);

            //
            if(transform.localPosition.x <= -8.4f)
            {
                transform.position = new Vector3(transform.position.x + 8.4f, transform.position.y, transform.position.z);
            }
        }
    }
}