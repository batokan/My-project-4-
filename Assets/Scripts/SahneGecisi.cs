using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçişleri için bu kütüphane şarttır

public class SahneGecisi : MonoBehaviour
{
    [Tooltip("Map1")]
    public string gidilecekSahneAdi;

    private bool icerideMi = false; // Karakterin alanın içinde olup olmadığını kontrol eder

    void Update()
    {
        // Karakter içerideyken 'X' tuşuna basarsa çalışır
        if (icerideMi && Input.GetKeyDown(KeyCode.X))
        {
            // Yeni sahneyi yükle
            SceneManager.LoadScene(gidilecekSahneAdi);
        }
    }

    // Karakter alanın (Tetikleyicinin) İÇİNE GİRİNCE çalışır
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icerideMi = true; // Karakter içeri girdi, artık tuşa basılabilir
        }
    }

    // Karakter alanın İÇİNDEN ÇIKINCA çalışır
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icerideMi = false; // Karakter dışarı çıktı, tuşa bassa bile çalışmaz
        }
    }
}
