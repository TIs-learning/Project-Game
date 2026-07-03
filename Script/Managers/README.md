# DeckManagers.cs

DeckManager adalah salah satu script inti (core system) karena bertanggung jawab membangun, mengacak, dan mengelola deck yang nantinya akan digunakan oleh HandManager dan sistem permainan lainnya. 
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

## Overview

`HandManager` merupakan script utama yang bertanggung jawab mengelola seluruh aktivitas kartu dalam permainan. Script ini menangani proses pembagian kartu, pengambilan kartu dari deck, permainan kartu oleh pemain maupun musuh, pelaksanaan efek kartu, serta pengaturan tampilan kartu selama permainan berlangsung.

---

# Variables

## Last Played Cards

```csharp
public CardData playerLastCard;
public CardData enemy1LastCard;
public CardData enemy2LastCard;
```

Menyimpan kartu terakhir yang dimainkan oleh Player, Enemy 1, dan Enemy 2. Data ini digunakan oleh efek **Repeat** untuk menjalankan kembali efek kartu terakhir yang dimainkan.

---

## Play Points

```csharp
public Transform playerPlayPoint;
public Transform enemy1PlayPoint;
public Transform enemy2PlayPoint;
```

Menentukan posisi tempat kartu dipindahkan setelah dimainkan sehingga kartu tidak lagi berada di tangan pemain.

---

## Card Back

```csharp
public Sprite cardBack;
```

Sprite yang digunakan sebagai tampilan belakang kartu musuh agar isi kartu tidak dapat dilihat oleh pemain.

---

## Hand References

```csharp
public Transform enemy1Hand;
public Transform enemy2Hand;
public Transform handArea;
```

Referensi lokasi penyimpanan kartu untuk Player, Enemy 1, dan Enemy 2.

---

## Card Prefab & Deck

```csharp
public GameObject cardPrefab;
public DeckManager deckManager;
```

- `cardPrefab` digunakan untuk membuat objek kartu baru.
- `deckManager` digunakan untuk mengambil kartu dari deck.

---

## Starting Hand Size

```csharp
public int startingHandSize = 5;
```

Menentukan jumlah kartu awal yang diterima setiap pemain saat permainan dimulai.

---

# Methods

## Start()

```csharp
void Start()
```

Method ini dipanggil secara otomatis ketika permainan dimulai.

### Fungsi

- Membuat deck baru.
- Mengacak isi deck.
- Membagikan kartu awal kepada Player.
- Membagikan kartu awal kepada Enemy 1.
- Membagikan kartu awal kepada Enemy 2.

---

## DrawStartingHand()

```csharp
void DrawStartingHand(Transform hand)
```

### Fungsi

Mengambil kartu dari deck sebanyak jumlah yang ditentukan pada `startingHandSize`.

Method ini memanggil `DrawCardToHand()` secara berulang hingga jumlah kartu awal terpenuhi.

---

## DrawCardToHand()

```csharp
public void DrawCardToHand(Transform hand)
```

### Fungsi

Mengambil satu kartu dari deck kemudian menambahkannya ke tangan pemain atau musuh.

### Proses

- Mengambil data kartu dari `DeckManager`.
- Membuat GameObject kartu baru.
- Menghubungkan komponen `CardDisplay`.
- Menampilkan informasi kartu.
- Jika kartu dimiliki musuh, gambar kartu diganti menggunakan `cardBack`.

---

## RemoveRandomCard()

```csharp
public void RemoveRandomCard(Transform hand)
```

### Fungsi

Menghapus satu kartu secara acak dari tangan target.

Method ini digunakan oleh efek **Attack** ketika target tidak memiliki Shield.

---

## RefreshHand()

```csharp
void RefreshHand(Transform ownerHand, int targetSize)
```

### Fungsi

Menambahkan kartu hingga jumlah kartu pada tangan pemain mencapai nilai yang ditentukan.

Method ini digunakan oleh efek **Fire Refresh**.

---

## ResolveEffect()

```csharp
void ResolveEffect(CardData card, Transform ownerHand)
```

### Fungsi

Method utama yang menjalankan efek kartu berdasarkan nilai `card.effect`.

Efek yang didukung antara lain:

### Draw

Menambahkan kartu ke tangan sebanyak nilai `card.value`.

---

### Attack

Menyerang salah satu lawan secara acak.

Jika target memiliki Shield:

- Shield akan dihapus.
- Serangan dibatalkan.

Jika target tidak memiliki Shield:

- Satu kartu target akan dihapus secara acak.

---

### Repeat

Mengulangi efek kartu terakhir yang dimainkan oleh pemilik kartu.

Efek Repeat tidak dapat mengulang efek Repeat lainnya untuk menghindari rekursi tanpa akhir.

---

### Shield

Mengaktifkan status Shield pada pemain sehingga serangan berikutnya dapat diblokir.

---

### Freeze

Memilih salah satu lawan secara acak kemudian memberikan status Frozen sehingga lawan akan melewati giliran berikutnya.

---

### Peek

Memperlihatkan seluruh kartu lawan selama dua detik.

Efek ini hanya dapat digunakan oleh Player.

---

### Fire Refresh

Mengisi kembali jumlah kartu di tangan hingga mencapai jumlah tertentu.

---

## RevealHand()

```csharp
IEnumerator RevealHand(Transform enemyHand)
```

### Fungsi

Coroutine yang digunakan oleh efek Peek.

### Proses

- Membuka seluruh kartu musuh.
- Menunggu selama dua detik.
- Mengembalikan kartu ke kondisi tertutup.

---

## PlayCard()

```csharp
public void PlayCard(CardDisplay card)
```

### Fungsi

Dipanggil ketika pemain memilih sebuah kartu.

Method akan:

- Memastikan bahwa saat ini merupakan giliran Player.
- Memulai proses memainkan kartu melalui coroutine `PlayPlayerCard()`.

---

## PlayPlayerCard()

```csharp
IEnumerator PlayPlayerCard(CardDisplay card)
```

### Fungsi

Menjalankan seluruh proses ketika Player memainkan kartu.

### Proses

- Menjalankan animasi perpindahan kartu.
- Menjalankan efek kartu.
- Memindahkan kartu ke area permainan.
- Mengakhiri giliran pemain.

---

## PlayEnemyCard()

```csharp
IEnumerator PlayEnemyCard(CardDisplay card, Transform ownerHand, Transform playPoint)
```

### Fungsi

Menjalankan proses permainan kartu milik musuh.

Proses yang dilakukan sama seperti Player namun dijalankan secara otomatis oleh AI.

---

## EnemyPlayCard()

```csharp
public void EnemyPlayCard(Transform enemyHand)
```

### Fungsi

Memilih satu kartu musuh secara acak kemudian memainkannya.

Method ini digunakan ketika giliran musuh berlangsung.

---

## IsHandEmpty()

```csharp
public bool IsHandEmpty(Transform hand)
```

### Fungsi

Memeriksa apakah suatu tangan masih memiliki kartu.

### Return

- `true` jika tangan kosong.
- `false` jika masih terdapat kartu.

---

## PlaceCard()

```csharp
void PlaceCard(CardDisplay card, Transform playPoint)
```

### Fungsi

Mengatur posisi kartu setelah selesai dimainkan.

### Proses

- Menghapus kartu sebelumnya pada area permainan.
- Memindahkan kartu ke Play Point.
- Mengatur ukuran kartu menjadi lebih kecil.
- Menampilkan artwork asli kartu.
- Menonaktifkan tombol klik.
- Menyimpan kartu sebagai kartu terakhir yang dimainkan apabila bukan kartu Repeat.

---

# Summary

`HandManager` merupakan pusat pengelolaan mekanisme kartu pada permainan. Script ini mengatur proses pembagian kartu, pengambilan kartu dari deck, permainan kartu oleh pemain maupun AI, pelaksanaan berbagai efek kartu seperti Draw, Attack, Repeat, Shield, Freeze, Peek, dan Fire Refresh, serta mengelola tampilan kartu dan penyimpanan kartu terakhir yang dimainkan. Dengan adanya script ini, seluruh mekanisme permainan kartu dapat berjalan secara terstruktur dan sesuai dengan aturan permainan.
