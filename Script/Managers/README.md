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


---

# HandManagers.cs
