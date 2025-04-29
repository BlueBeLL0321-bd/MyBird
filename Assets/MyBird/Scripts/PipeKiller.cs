using UnityEngine;

namespace MyBird
{
    // Pipe Killer와 충돌하는 모든 충돌체는 kill한다
    public class PipeKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}