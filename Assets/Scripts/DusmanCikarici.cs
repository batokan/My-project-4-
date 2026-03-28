using UnityEngine;

public class DusmanCikarici : MonoBehaviour
{
    public GameObject dusmanPrefab;
    public float uretimHizi = 2f;

    // Yeni eklediğimiz kısım: Oyuncu referansı ve güvenli çemberin yarıçapı
    public Transform oyuncu; 
    public float guvenliMesafe = 5f; 

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        InvokeRepeating("RastgeleUret", 1f, uretimHizi);
    }

    void RastgeleUret()
    {
        Vector2 dogumYeri = Vector2.zero;
        bool guvenliYerBulundu = false;
        int deneme = 0; // Oyunun kilitlenmemesi için bir sınır koy

        // Oyuncuya yeterince uzak bir yer bulana kadar (maksimum 30 kere) rastgele yer seç
        while (!guvenliYerBulundu && deneme < 30)
        {
            float rastgeleX = Random.Range(minX, maxX);
            float rastgeleY = Random.Range(minY, maxY);
            dogumYeri = new Vector2(rastgeleX, rastgeleY);

            // Seçilen yer ile oyuncu arasındaki mesafeyi ölçme
            if (oyuncu != null && Vector2.Distance(dogumYeri, oyuncu.position) > guvenliMesafe)
            {
                guvenliYerBulundu = true; // Yeterince uzak, burası uygun!
            }
            deneme++;
        }

        // Güvenli yer bulunduysa düşmanı oraya yerleştir
        if (guvenliYerBulundu)
        {
            Instantiate(dusmanPrefab, dogumYeri, Quaternion.identity);
        }
    }
}