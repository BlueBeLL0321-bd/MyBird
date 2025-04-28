using UnityEngine;

namespace MyBird
{
    // ī�޶� ���� - �÷��̾� �̵��� ���� ���� �̵��Ѵ�
    public class CameraController : MonoBehaviour
    {
        #region Variables
        // �÷��̾� ������Ʈ
        public Transform player;

        // ī�޶� ��ġ offset
        [SerializeField] private float offsetX = 1.5f;
        #endregion

        private void Start()
        {
            // ī�޶� ��ġ �ʱ�ȭ
            FollowPlayer();
        }

        private void Update()
        {
            FollowPlayer();
        }

        // ī�޶��� ��ġ�� �÷��̾��� ��ġ���� z�������� -10��ŭ ��ġ�ϰ� �����
        // ī�޶��� ��ġ���� �÷��̾��� x��ġ ���� �����ϰ� ���󰣴�, offsetX ����
        void FollowPlayer()
        {
            // �÷��̾�� ������ ��ġ
            // this.transform.position = player.position;
            this.transform.position = new Vector3(player.position.x + offsetX, transform.position.y, this.transform.position.z);
        }
    }
}