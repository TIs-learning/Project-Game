# Desc Game

---
# 🎮 Game Overview

## Genre
Multiplayer Strategy Card Game

## Objective
Menjadi pemain terakhir yang masih memiliki kartu. Pemain dinyatakan kalah ketika seluruh kartu yang dimilikinya habis.

---

# Core Gameplay

- Setiap pemain memilih satu elemen (Fire, Ice, atau Shadow).
- Permainan berlangsung secara bergiliran.
- Pemain menggunakan kartu untuk menyerang, bertahan, atau mengaktifkan efek khusus.
- Setiap elemen memiliki strategi dan kemampuan unik.
- Ultimate Card dapat digunakan setelah pemain mengorbankan 2 Element Symbol.

---

# Card Types

## Neutral Cards
Kartu dasar yang dapat digunakan oleh seluruh pemain.

| Card | Function |
|-------|----------|
| Draw | Mengambil kartu dari deck. |
| Attack | Membuang 2 kartu milik lawan. |
| Protector | Melindungi pemain dari serangan. |
| Shield | Menahan efek tertentu. |
| Wild Card | Menyalin efek kartu lain. |

## Element Cards
Kartu khusus berdasarkan elemen yang dipilih pemain. Setiap pemain hanya dapat menggunakan satu jenis elemen.

## Trap Cards
- Diletakkan dalam keadaan tertutup (Face Down).
- Aktif secara otomatis ketika syarat tertentu terpenuhi.
- Setelah aktif, kartu langsung dibuang.

## Interrupt Cards
- Dapat dimainkan di luar giliran pemain.
- Pada prototype hanya dimiliki oleh elemen Fire.

## Ultimate Cards
- Tidak dapat digunakan kapan saja.
- Membutuhkan pengorbanan 2 Element Symbol.
- Memiliki kemampuan paling kuat dibanding kartu lainnya.
- Efek Ultimate hanya dapat aktif satu kali setiap kartu dimainkan.

---

# Win & Lose Condition

## Win
Menjadi pemain terakhir yang masih memiliki kartu.

## Lose
Pemain kalah ketika seluruh kartu yang dimilikinya habis.

---

# Elements

## 🔥 Fire
Karakteristik:
- Mempercepat tempo permainan.
- Berfokus pada efek ofensif.
- Memiliki Interrupt Card.

Ultimate:
- Mendapat satu giliran tambahan.
- Semua efek kartu Fire bertambah +2 selama efek Ultimate berlangsung.

---

## ❄️ Ice
Karakteristik:
- Memperlambat tempo permainan.
- Mengontrol giliran lawan.

Ultimate:
- Pilih satu pemain selama satu putaran.
- Jika pemain tersebut diserang:
  - Serangan dibatalkan.
  - Penyerang terkena efek Frozen.
- Jika tidak ada serangan:
  - Pemain Ice mengambil 2 kartu.
- Efek ini bekerja melalui mekanisme Trap Card.

---

## 🌑 Shadow
Karakteristik:
- Mengelabui lawan.
- Berfokus pada manipulasi kartu.

Ultimate:
- Kartu berikutnya yang dimainkan oleh pemain selanjutnya menjadi milik pemain Shadow.

---

# Gameplay Notes

- Setiap pemain hanya dapat menggunakan satu elemen.
- Ultimate membutuhkan 2 Element Symbol.
- Trap aktif secara otomatis.
- Interrupt dapat dimainkan di luar giliran.
- Efek Ultimate hanya berlaku satu kali penggunaan.

---

# Struktur Folder 

```text
Game-Project/
│
├── README.md
├── LICENSE
├── docs/
│   ├── GameDesign.md
│   ├── GameplayRules.md
│   ├── CardList.md
│   ├── GameFlow.md
│   └── UML/
│
├── Assets/
│   ├── Art/
│   ├── Audio/
│   ├── Fonts/
│   └── UI/
│
├── Scripts/
├── Scenes/
├── Prefabs/
├── Materials/
├── Animation/
├── Packages/
└── ProjectSettings/
```

---

# Pengembangan Selanjutnya?
1. 📖 Game Overview (konsep game)
2. 🎲 Gameplay Rules (aturan permainan)
3. 🃏 Card Database (detail semua kartu)
4. ⚖️ Game Balance (damage, cooldown, biaya, dll.)
5. 🔄 Game Flow (alur permainan dari awal hingga akhir)
6. 🏗️ Architecture (struktur folder, scene, dan script)
