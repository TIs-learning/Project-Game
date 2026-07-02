// Import Library
using System.Collections;
using UnityEngine;

// Definisi Class (Inheritance)
public class CardAnimator : MonoBehaviour
{    
    // Method MoveTo()
    public IEnumerator MoveTo(Transform target, float duration)
    {
        // Menyimpan Data Awal
        Vector3 start = transform.position;
        Vector3 end = target.position;

        // Menentukan Perubahan Skala
        Vector3 startScale = transform.localScale;
        Vector3 endScale = startScale * 0.75f;

        // Menentukan Rotasi
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(0,0,8);

        // Inisialisasi Timer
        float timer = 0f;

        // Perulangan Animasi
        while (timer < duration)
        {    
            // Menghitung Progress
            float t = timer / duration;

            // SmoothStep
            t = t * t * (3f - 2f * t);   

            // Memindahkan Kartu
            transform.position = Vector3.Lerp(start, end, t);

            // Mengubah Ukuran
            transform.localScale = Vector3.Lerp(startScale, endScale, t);

            // Mengubah Rotasi
            transform.rotation = Quaternion.Lerp(startRot, endRot, t);

            // Menambah Timer
            timer += Time.deltaTime;

            // Menunggu Frame Berikutnya
            yield return null;
        }

        // Menyelesaikan Animasi
        transform.position = end;
    }
}
