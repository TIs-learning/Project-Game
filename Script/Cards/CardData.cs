// Import Library
using UnityEngine;

// Membuat Asset Menu baru
[CreateAssetMenu(fileName = "New Card", menuName = "Card Game/Card")]

// Deklarasi kelas
public class CardData : ScriptableObject{

    // Basic Info
    [Header("Basic Info")]
    // Nama kartu
    public string cardName;
    // Deskripsi
    [TextArea]
    public string description;
    // Menyimpan gambar kartu
    public Sprite artwork;

    // Menyimpan judul kedua pada inspector
    [Header("Card Properties")]
    // Menentukan elemen kartu.
    public CardElement element;
    // Menentukan jenis kartu.
    public CardKind kind;
    // Menentukan efek yang dimiliki kartu.
    public EffectType effect;
    // Besarnya efek kartu.
    public int value;
    // Menentukan apakah kartu memiliki Element Symbol.
    public bool hasSymbol;
}
