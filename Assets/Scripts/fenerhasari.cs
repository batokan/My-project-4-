using UnityEngine;

public class FenerHasari : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D temasEden)
    {
        if (temasEden.gameObject.CompareTag("Dusman"))
        {
            // Virgül koyup 1f yazdık. "f" harfi float (küsuratlı sayı) demek.
            // Bu sayede düşman ışığa değdikten tam 1 saniye sonra yok olacak.
            Destroy(temasEden.gameObject, 1f);
        }
    }
}