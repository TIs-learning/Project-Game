# DeckManagers.cs

DeckManager adalah salah satu script inti (core system) karena bertanggung jawab membangun, mengacak, dan mengelola deck yang nantinya akan digunakan oleh HandManager dan sistem permainan lainnya. Untuk dokumentasi, saya menyarankan membuat tiga flowchart terpisah (GenerateDeck, ShuffleDeck, dan DrawCard) seperti di atas agar setiap fungsi mudah dipahami dan tidak membuat satu diagram menjadi terlalu padat.

1. Script DeckManager menggunakan dua library utama, yaitu System.Collections.Generic dan UnityEngine.

Library	Fungsi
- System.Collections.Generic	Menyediakan koleksi data seperti List<T> yang digunakan untuk menyimpan kumpulan kartu.
- UnityEngine	Menyediakan fitur utama Unity seperti MonoBehaviour, Random, Debug, dan atribut Header

2. Bagian ini menyimpan seluruh kumpulan kartu berdasarkan elemen.

```text
Neutral Cards
├── Draw
├── Attack
├── Shield
└── Wild

Fire Cards
├── Fire Blast
├── Fire Refresh
└── Fire Ultimate

Ice Cards
├── Freeze
├── Ice Bomb
└── Ice Supply

Shadow Cards
├── Peek
├── Guess
└── Confuse
```

Semua list ini biasanya diisi melalui Inspector Unity.

3. Merupakan deck yang benar-benar digunakan selama permainan.

Misalnya setelah deck dibuat:
-. Draw
-. Attack
-. Fire Blast
-. Shield
-. Freeze

4. Menentukan jumlah kartu yang akan dibuat. Pada script ini deck akan selalu berisi

5. Parameter

- element: menentukan deck pemain. Contoh: 
- GenerateDeck(Fire)

↓

Deck akan berisi

75% Neutral
25% Fire

6. Jika sebelumnya deck sudah ada

Old Deck

↓

Dihapus

7. Perulangan sebanyak

- 300 kali (contoh): Setiap perulangan akan menambahkan satu kartu.

75%

↓

Neutral

25%

↓

Element Card

Contoh

Random = 0.60

↓

Neutral
Random = 0.90

↓

Element

8. Mengambil satu kartu neutral secara acak.

9. Masuk ke

switch(element)

Misalnya

Fire

↓

Mengambil kartu acak dari

fireCards

Jika

Ice

↓

Mengambil dari

iceCards

Begitu juga Shadow.

10. Deck Selesai

11. Digunakan untuk mengacak urutan deck.
    
12. Memilih index secara acak

13. *Sebelum

Draw

Attack

Shield

*Sesudah

Shield

Draw

Attack

14. Berfungsi mengambil satu kartu dari deck.

15. if(deck.Count==0)

Jika kosong

↓

Deck is Empty

↓

return

null

16. ardData drawnCard=deck[0];

Misalnya

Draw
Attack
Shield

↓

yang diambil

Draw

17. deck.RemoveAt(0);

Sisa deck menjadi

- Attack
- Shield

18. Mengembalikan kartu yang diambil.

---

# GameManager.cs

1. Library	Fungsi
- System.Collections	Digunakan untuk IEnumerator pada Coroutine (EnemyTurn()).
- UnityEngine	Menyediakan MonoBehaviour, Debug, WaitForSeconds, FindFirstObjectByType, dan fungsi dasar Unity lainnya.
- TMPro	Menampilkan teks giliran menggunakan TMP_Text.
- UnityEngine.UI	Mengontrol komponen UI seperti Image untuk ikon Shield dan Freeze.

2. Menentukan apakah pemain sedang terkena efek Freeze.
Jika bernilai true, maka giliran pemain tersebut akan dilewati satu kali.  

3. Menentukan apakah pemain masih berada dalam permainan.
Jika false, maka pemain akan dilewati pada sistem pergantian giliran.

4. Menentukan apakah pemain sedang memiliki efek Shield.

5. Menentukan giliran yang sedang berlangsung.

6. Digunakan agar script lain dapat mengakses GameManager tanpa harus mencari GameObject.

7. Dijalankan saat GameObject dibuat.

8. Mengaktifkan atau menonaktifkan ikon Shield sesuai status pemain.

9. Menampilkan ikon Freeze ketika pemain terkena efek Freeze.

10. Mengubah tulisan pada UI.

11. Fungsinya:

- Mengganti giliran.
- Melewati pemain yang kalah.
- Mengecek Freeze.
- Menjalankan AI musuh.
- Mengecek kondisi kalah.

Langkah 1
Player

↓

Enemy1

↓

Enemy2

↓

Player

Pergantian dilakukan menggunakan

Langkah 2

Jika ada pemain yang sudah kalah

Enemy1 Alive = false

↓

Enemy1 dilewati

Hal ini dilakukan menggunakan

Langkah 3

Update tulisan giliran.

Current Turn

↓

PLAYER TURN

Langkah 4

Cek kondisi kalah.

Hand kosong?

↓

Player kalah

Langkah 5

Cek Freeze.

Misalnya

Enemy1 Frozen

↓

Skip Turn

↓

Freeze dihapus

↓

Lanjut ke pemain berikutnya

Langkah 6

Jika sekarang giliran musuh

Enemy1

↓

EnemyTurn()

Coroutine yang menjalankan AI musuh.

Langkahnya

Tunggu 1 detik

↓

Cari HandManager

↓

Mainkan kartu musuh

↓

Tunggu 0.5 detik

↓

EndTurn()

12. Mengecek apakah tangan pemain kosong.

---

# HandManagers.cs
