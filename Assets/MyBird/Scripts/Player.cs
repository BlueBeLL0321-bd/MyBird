using UnityEngine;

namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;

        // 애니메이터
        public Animator animator;

        // 점프
        private bool keyJump = false;       // 점프 키 인풋 체크
        [SerializeField]
        private float jumpForce = 5f;       // 위 방향으로 주는 힘

        // 회전
        private Vector3 birdRotation;
        // 위로 올라갈 때 회전 속도
        [SerializeField] private float upRotate = 2.5f;
        // 아래로 내려갈 때 회전 속도
        [SerializeField] private float downRotate = 5f;

        // 이동
        // 이동 속도 - Translate 시작하면 자동 오른쪽으로 이동
        [SerializeField] private float moveSpeed = 5f;

        // 대기
        // 아래로 떨어지지 않을 만큼의 새를 받치는 힘
        [SerializeField] private float readyForce = 1f;

        // UI
        public GameObject readyUI;
        public GameObject resultUI;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // 참조
            rb2D = this.GetComponent<Rigidbody2D>();

            // 초기화
        }

        // Update is called once per frame
        void Update()
        {
            // 인풋 처리
            InputBird();

            if (GameManager.IsStart == false)
            {
                // 버드 대기
                ReadyBird();
                return;
            }

            // 버드 회전
            RotateBird();

            // 버드 이동
            MoveBird();
        }

        void FixedUpdate()
        {
            // 점프하기
            if (keyJump)
            {
                JumpBird();
                keyJump = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // collision : 부딪힌 콜라이더 정보를 가지고 있다
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
        // 인풋 처리
        void InputBird()
        {
            if (GameManager.IsDeath == true)
                return;

            // 스페이스 키 또는 마우스 왼클릭 입력 받기
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            // 게임 시작 전이고 점프 키가 눌리면
            if(GameManager.IsStart == false && keyJump == true)
            {
                StartMove();
            }

        }

        // 버드 점프하기
        void JumpBird()
        {
            // 아래쪽에서 위쪽으로 힘을 준다
            // rb2D.AddForce(Vector2.up * jumpForce(힘));
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        // 버드 회전하기
        void RotateBird()
        {
            // 올라갈 때 최대 +50도까지 회전 : rotateSpeed = 2.5(upRotate);
            // 내려갈 때 최소 -90도까지 회전 : rotateSpeed = 5(downRotate);
            float rotateSpeed = 0f;
            if(rb2D.linearVelocity.y > 0f)  // 올라갈 때
            {
                rotateSpeed = upRotate;
            }
            else if(rb2D.linearVelocity.y < 0f) // 내려갈 때
            {
                rotateSpeed = downRotate;
            }

            birdRotation = new Vector3(0f, 0f, Mathf.Clamp((birdRotation.z + rotateSpeed), -90f, 30f));
            this.transform.eulerAngles = birdRotation;
        }

        // 버드 대기
        void ReadyBird()
        {
            // 아래쪽에서 떨어지지 않도록 위쪽으로 힘을 준다
            if(rb2D.linearVelocity.y < 0f)
                rb2D.linearVelocity = Vector2.up * readyForce;
        }

        // 버드 이동
        void MoveBird()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;

            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        // 버드 죽음
        void DieBird()
        {
            // 두 번 죽음 체크
            if (GameManager.IsDeath)
                return;

            GameManager.IsDeath = true;
            animator.enabled = false;
            rb2D.linearVelocity = Vector2.zero;

            // VFX, SFX

            // UI
            resultUI.SetActive(true);
        }

        // 버드 이동 시작
        void StartMove()
        {
            GameManager.IsStart = true;
            readyUI.SetActive(false);
        }
        #endregion
    }
}