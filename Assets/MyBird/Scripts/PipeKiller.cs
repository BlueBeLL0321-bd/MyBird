using UnityEngine;

namespace MyBird
{
    // Pipe Killer�� �浹�ϴ� ��� �浹ü�� kill�Ѵ�
    public class PipeKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}