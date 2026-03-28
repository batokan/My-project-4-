using UnityEngine;
using UnityEngine.SceneManagement; // Ölünce sahneyi baştan yüklemek için

public class SuzulenDusman : MonoBehaviour
{
    [Header("Düşman Ayarları")]
    public float hareketHizi = 2f; // Düşmanın hızı

    private Transform playerTransform; // Oyuncunun pozisyonunu tutacak

    void Start()
    {
        // Oyun başladığında, sahnede "Player" tag'ine (etiketine) sahip objeyi bul
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // Eğer oyuncu varsa ve yaşıyorsa
        if (playerTransform != null)
        {
            // Oyuncuya doğru süzülerek ilerle
            Vector3 yon = playerTransform.position - transform.position;
            transform.position += yon.normalized * hareketHizi * Time.deltaTime;
        }
    }

    // Çarpışma olduğunda çalışır
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer çarptığım objenin tag'i (etiketi) "Player" ise
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncu öldü! Sahneyi baştan yükle (Hızlı çözüm)
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
            
            // Alternatif: Oyuncu objesini yok edebilirsin:
            // Destroy(collision.gameObject);
        }
    }
}