using UnityEngine;

public class AsansorKontrol : MonoBehaviour
{
    [Tooltip("Asansörün Animator'ünün bulunduğu objeyi buraya sürükleyin")]
    public Animator asansorAnim; // Artık Animator'ü Unity'nin içinden biz atayacağız
    private bool acildiMi = false;

    // Dikkat: Start fonksiyonunu sildik çünkü otomatik aramaya gerek kalmadı.

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer asansör animatörü boş değilse, karaktere (Player) değdiyse ve asansör daha açılmadıysa
        if (asansorAnim != null && other.CompareTag("Player") && !acildiMi)
        {
            asansorAnim.SetTrigger("AsansorAc"); // Animator'daki tetikleyiciyi ateşle (İsmi ne yaptıysanız: Acil veya AsansorAc)
            acildiMi = true;
        }
        else if (asansorAnim == null)
        {
            Debug.LogWarning("Asansör Animatörünü Inspector'dan sürüklemeyi unuttunuz!");
        }
    }
}
