using UnityEngine;

public class FenerHasari : MonoBehaviour
{
    // Işığın Tetikleyici (Trigger) alanına bir obje girdiğinde çalışır
    void OnTriggerEnter2D(Collider2D temasEden)
    {
        // Eğer giren objenin etiketi (Tag) "Dusman" ise
        if (temasEden.gameObject.CompareTag("Dusman"))
        {
            // O düşman objesini anında sahneden yok et
            Destroy(temasEden.gameObject);
            
            // Alternatif: Buraya bir toz olma efekti veya ses de ekleyebiliriz
            Debug.Log("Düşman ışıkla eritildi!");
        }
    }
}