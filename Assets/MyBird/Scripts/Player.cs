using UnityEngine;

namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;

        // �ִϸ�����
        public Animator animator;

        // ����
        private bool keyJump = false;       // ���� Ű ��ǲ üũ
        [SerializeField]
        private float jumpForce = 5f;       // �� �������� �ִ� ��

        // ȸ��
        private Vector3 birdRotation;
        // ���� �ö� �� ȸ�� �ӵ�
        [SerializeField] private float upRotate = 2.5f;
        // �Ʒ��� ������ �� ȸ�� �ӵ�
        [SerializeField] private float downRotate = 5f;

        // �̵�
        // �̵� �ӵ� - Translate �����ϸ� �ڵ� ���������� �̵�
        [SerializeField] private float moveSpeed = 5f;

        // ���
        // �Ʒ��� �������� ���� ��ŭ�� ���� ��ġ�� ��
        [SerializeField] private float readyForce = 1f;

        // UI
        public GameObject readyUI;
        public GameObject resultUI;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // ����
            rb2D = this.GetComponent<Rigidbody2D>();

            // �ʱ�ȭ
        }

        // Update is called once per frame
        void Update()
        {
            // ��ǲ ó��
            InputBird();

            if (GameManager.IsStart == false)
            {
                // ���� ���
                ReadyBird();
                return;
            }

            // ���� ȸ��
            RotateBird();

            // ���� �̵�
            MoveBird();
        }

        void FixedUpdate()
        {
            // �����ϱ�
            if (keyJump)
            {
                JumpBird();
                keyJump = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // collision : �ε��� �ݶ��̴� ������ ������ �ִ�
            if(collision.gameObject.tag == "Ground")
            {
                DieBird();
            }
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Point")
            {
                GameManager.Score++;
            }
            else if (collision.gameObject.tag == "Pipe")
            {
                DieBird();
            }
        }
        #endregion

        #region Custom Method
        // ��ǲ ó��
        void InputBird()
        {
            if (GameManager.IsDeath == true)
                return;

            // �����̽� Ű �Ǵ� ���콺 ��Ŭ�� �Է� �ޱ�
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            // ���� ���� ���̰� ���� Ű�� ������
            if(GameManager.IsStart == false && keyJump == true)
            {
                StartMove();
            }

        }

        // ���� �����ϱ�
        void JumpBird()
        {
            // �Ʒ��ʿ��� �������� ���� �ش�
            // rb2D.AddForce(Vector2.up * jumpForce(��));
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        // ���� ȸ���ϱ�
        void RotateBird()
        {
            // �ö� �� �ִ� +50������ ȸ�� : rotateSpeed = 2.5(upRotate);
            // ������ �� �ּ� -90������ ȸ�� : rotateSpeed = 5(downRotate);
            float rotateSpeed = 0f;
            if(rb2D.linearVelocity.y > 0f)  // �ö� ��
            {
                rotateSpeed = upRotate;
            }
            else if(rb2D.linearVelocity.y < 0f) // ������ ��
            {
                rotateSpeed = downRotate;
            }

            birdRotation = new Vector3(0f, 0f, Mathf.Clamp((birdRotation.z + rotateSpeed), -90f, 30f));
            this.transform.eulerAngles = birdRotation;
        }

        // ���� ���
        void ReadyBird()
        {
            // �Ʒ��ʿ��� �������� �ʵ��� �������� ���� �ش�
            if(rb2D.linearVelocity.y < 0f)
                rb2D.linearVelocity = Vector2.up * readyForce;
        }

        // ���� �̵�
        void MoveBird()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;

            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        // ���� ����
        void DieBird()
        {
            // �� �� ���� üũ
            if (GameManager.IsDeath)
                return;

            GameManager.IsDeath = true;
            animator.enabled = false;
            rb2D.linearVelocity = Vector2.zero;

            // VFX, SFX

            // UI
            resultUI.SetActive(true);
        }

        // ���� �̵� ����
        void StartMove()
        {
            GameManager.IsStart = true;
            readyUI.SetActive(false);
        }
        #endregion
    }
}