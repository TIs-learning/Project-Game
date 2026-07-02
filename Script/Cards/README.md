### File CardAnimator.cs
1. Library yang digunakan:
- System.Collections → Mendukung penggunaan IEnumerator untuk Coroutine.
- UnityEngine → Menyediakan berbagai class Unity seperti Transform, Vector3, Quaternion, dan Time

2. Mendefinisikan sebuah class bernama CardAnimator yang mewarisi (inherit) MonoBehaviour, sehingga script dapat dipasang pada GameObject di Unity.
   
3. Method ini merupakan Coroutine yang menerima dua parameter.
- Parameter	Fungsi
- target	Posisi tujuan kartu
- duration	Lama animasi

4. Digunakan untuk menyimpan:
- posisi awal kartu
- posisi tujuan kartu

5. Selama animasi berlangsung ukuran kartu berubah menjadi 75% dari ukuran semula.
   
6. Rotasi awal diambil dari posisi saat ini, kemudian kartu diputar hingga 8° pada sumbu Z.
   
7. Timer digunakan untuk menghitung progres animasi.
    
8. Selama waktu animasi belum habis, Unity akan terus memperbarui posisi kartu setiap frame.
    
9. Nilai t selalu berada di antara 0 hingga 1

10. Digunakan agar gerakan:

- mulai perlahan
- semakin cepat
- kemudian melambat saat mendekati tujuan
Animasi menjadi lebih natural dibanding perpindahan linear biasa.

11. Vector3.Lerp() melakukan interpolasi posisi dari start menuju end.
    
12. Ukuran kartu diperkecil secara bertahap.
    
13. Rotasi kartu berubah sedikit demi sedikit hingga mencapai sudut tujuan.
    
14. Timer bertambah sesuai waktu antar frame sehingga animasi memiliki durasi yang konsisten pada berbagai FPS.
    
15. Coroutine dihentikan sementara hingga frame berikutnya, kemudian proses animasi dilanjutkan.
    
16. Memastikan posisi akhir benar-benar sama dengan target.

---

### File CardData.cs

1. Mengimpor library Unity yang menyediakan berbagai class dasar seperti ScriptableObject, Sprite, dan atribut Inspector

2. Atribut ini membuat menu baru pada Unity.

3. Ketika dipilih, Unity otomatis membuat asset baru bertipe CardData.

Nama awal asset adalah: New Card 

4. CardData merupakan turunan dari ScriptableObject.

Artinya objek ini hanya menyimpan data dan tidak perlu ditempel pada GameObject seperti MonoBehaviour.

Perbedaannya:

MonoBehaviour	ScriptableObject
Menempel pada GameObject	Berupa Asset
Digunakan untuk logika game	Digunakan untuk menyimpan data
Ada di Scene	Ada di Project

5. Memberi judul Basic Info pada Inspector.

6. Membuat public nama kartu contoh: fire attack

7. TextArea membuat kotak teks yang lebih besar di Inspector.

8. Menyimpan gambar kartu.

9. Memberi judul kedua pada Inspector.

10. Menentukan elemen kartu.

Misalnya

Fire
Ice
Shadow
Neutral

Biasanya CardElement adalah enum

11. Menentukan jenis kartu.

12. Menentukan efek yang dimiliki kartu.

13. Besarnya efek kartu.

14. Menentukan apakah kartu memiliki Element Symbol.
    
---

### File CardDisplay.cs

1. Library yang digunakan:

Library	Fungsi
- UnityEngine	Fitur dasar Unity
- UnityEngine.UI	Menggunakan komponen UI seperti Image
- UnityEngine.EventSystems	Mendeteksi event mouse (Hover, Click, Exit)

2. Script ini mengimplementasikan tiga interface.

3. IPointerEnterHandler

Dipanggil ketika mouse masuk ke area kartu.

4. IPointerExitHandler

Dipanggil ketika mouse keluar dari kartu.

5. IPointerClickHandler

Dipanggil ketika kartu diklik.

6. Menentukan apakah kartu ini milik pemain.

Jika

true

maka kartu dapat dimainkan.

Jika

false

klik akan diabaikan.

Biasanya digunakan agar kartu lawan tidak bisa dimainkan.

7. Menyimpan informasi kartu.

8. Komponen UI yang menampilkan gambar kartu.

9. Referensi menuju HandManager.

Saat pemain memainkan kartu, script ini akan memanggil

10. Method ini digunakan untuk mengisi tampilan kartu.

Menyimpan data kartu. Kemudian Mengubah gambar kartu sesuai data.


11. Saat mouse masuk

↓

HOVER

ditampilkan pada Console.

Saat ini hanya digunakan untuk debugging.

12. Dipanggil ketika mouse keluar dari kartu.

Saat ini hanya debugging.

13. Method ini kemungkinan digunakan untuk pengujian tombol di Inspector.

14. Method sederhana yang meminta HandManager memainkan kartu ini.

15. Jika kartu bukan milik pemain

↓

proses dihentikan.

16. Menampilkan log bahwa kartu berhasil diklik

17. Memastikan HandManager ada.

18. Kalau ada

↓
dipanggil.

Kalau tidak ada

↓

HAND MANAGER IS NULL

ditampilkan agar programmer tahu ada kesalahan.

---

### File CardElement.cs

CardElement adalah enum yang mendefinisikan jenis elemen kartu dalam permainan (Neutral, Fire, Ice, Shadow). Enum ini digunakan oleh CardData untuk menyimpan identitas elemen setiap kartu dan menjadi dasar berbagai mekanik permainan seperti efek khusus, ultimate, dan strategi masing-masing elemen.

---

### File CardKind.cs

CardKind adalah sebuah enumeration (enum) yang digunakan untuk mendefinisikan jenis-jenis kartu yang tersedia dalam permainan. Dengan menggunakan enum, setiap kartu hanya dapat memiliki satu kategori yang telah ditentukan sehingga memudahkan sistem dalam mengidentifikasi perilaku kartu saat dimainkan

---

### File EffectType.cs
