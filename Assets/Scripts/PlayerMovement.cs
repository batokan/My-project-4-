using UnityEngine;

// 1. DUVARLARDAN GEÇMEMESİ İÇİN RIGIDBODY GERİ GELDİ!
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController2D : MonoBehaviour
{
    [Header("=== HAREKET AYARLARI ===")]
    public float hareketHizi = 8f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 hareketGirdisi;
    private bool sagaBakiyor = false;
    private bool oluMu = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Senin demin istediğin o "özgür hareket" hissini vermek için yerçekimini kodla 0 yapıyoruz.
        rb.gravityScale = 0f;
        // Duvarların köşesine çarpınca topaç gibi dönmesini engelliyoruz.
        rb.freezeRotation = true;

        // Hızlı koşarken duvar delme (Tunneling) bugına karşı önlemimiz:
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        if (oluMu) return;

        // Hem X (Sağ-Sol) hem Y (Yukarı-Aşağı) Tuşlarını Algıla
        hareketGirdisi.x = Input.GetAxisRaw("Horizontal");
        hareketGirdisi.y = Input.GetAxisRaw("Vertical");

        hareketGirdisi = hareketGirdisi.normalized;

        // Ateş Etme 
        if (Input.GetButtonDown("Fire1")) { anim.SetTrigger("AtesEt"); }

        // Test İçin Ölme Tuşu
        if (Input.GetKeyDown(KeyCode.K))
        {
            oluMu = true;
            anim.SetBool("Olu", true);
            rb.linearVelocity = Vector2.zero; // Ölünce kayıp gitmesin
            return;
        }

        YonuCevir();
        anim.SetFloat("Hiz", hareketGirdisi.magnitude);
    }

    // 2. IŞINLANMA YERİNE FİZİKSEL YÜRÜME!
    void FixedUpdate()
    {
        if (!oluMu)
        {
            // transform.Translate SİLDİK! Artık fizik objesine hız (velocity) vererek ilerletiyoruz. 
            // Duvarlar ve Box Collider'lar artık bu hızı engelleyebilecek!
            rb.linearVelocity = hareketGirdisi * hareketHizi;
        }
    }

    private void YonuCevir()
    {
        if (sagaBakiyor && hareketGirdisi.x < 0f || !sagaBakiyor && hareketGirdisi.x > 0f)
        {
            sagaBakiyor = !sagaBakiyor;
            Vector3 lokalOlcek = transform.localScale;
            lokalOlcek.x *= -1f;
            transform.localScale = lokalOlcek;
        }
    }
}
