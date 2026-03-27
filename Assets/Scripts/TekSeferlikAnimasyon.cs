using UnityEngine;

public class TekSeferlikAnimasyon : MonoBehaviour
{
    // Oynatılacak animasyonun kime ait olduğu (Kendi üstünde de olabilir, başka bir yerde de)
    public Animator hedefAnimator;

    // Animasyonun tekrar çalışmasını engellemek için kontrol değişkeni
    private bool oynatildiMi = false;

    // Sınırlar (Trigger) içerisine bir şey girdiğinde çalışır (Sadece 2D için)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Giren obje karakterimizse (Tag'ı "Player" olarak ayarlı olmalı) 
        // ve animasyon daha önce HİÇ oynatılmadıysa
        if (collision.CompareTag("Player") && !oynatildiMi)
        {
            // Animator içindeki 'Oynat' tetikleyicisini çalıştır
            hedefAnimator.SetTrigger("Oynat");

            // Bir daha çalışmasın diye true yapıyoruz
            oynatildiMi = true;

            // Alternatif olarak bu trigger nesnesini tamamen silebilirsin (isteğe bağlı)
            // Destroy(gameObject); 
        }
    }
}
