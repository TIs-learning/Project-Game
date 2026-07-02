### File CardAnimator.cs
1. Library yang digunakan:

System.Collections → Mendukung penggunaan IEnumerator untuk Coroutine.
UnityEngine → Menyediakan berbagai class Unity seperti Transform, Vector3, Quaternion, dan Time

2. Mendefinisikan sebuah class bernama CardAnimator yang mewarisi (inherit) MonoBehaviour, sehingga script dapat dipasang pada GameObject di Unity.
   
3. Method ini merupakan Coroutine yang menerima dua parameter.

Parameter	Fungsi
target	Posisi tujuan kartu
duration	Lama animasi

4. Digunakan untuk menyimpan:

posisi awal kartu
posisi tujuan kartu

5. Selama animasi berlangsung ukuran kartu berubah menjadi 75% dari ukuran semula.
   
6. Rotasi awal diambil dari posisi saat ini, kemudian kartu diputar hingga 8° pada sumbu Z.
   
7. Timer digunakan untuk menghitung progres animasi.
    
8. Selama waktu animasi belum habis, Unity akan terus memperbarui posisi kartu setiap frame.
    
9. Nilai t selalu berada di antara

0
hingga
1

10. Digunakan agar gerakan:

mulai perlahan
semakin cepat
kemudian melambat saat mendekati tujuan

Animasi menjadi lebih natural dibanding perpindahan linear biasa.

11. Vector3.Lerp() melakukan interpolasi posisi dari start menuju end.
    
12. Ukuran kartu diperkecil secara bertahap.
    
13. Rotasi kartu berubah sedikit demi sedikit hingga mencapai sudut tujuan.
    
14. Timer bertambah sesuai waktu antar frame sehingga animasi memiliki durasi yang konsisten pada berbagai FPS.
    
15. Coroutine dihentikan sementara hingga frame berikutnya, kemudian proses animasi dilanjutkan.
    
16. Memastikan posisi akhir benar-benar sama dengan target.

---

### File CardData.cs

---

### File CardDisplay.cs

---

### File CardElement.cs

---

### File CardKind.cs

---

### File EffectType.cs
