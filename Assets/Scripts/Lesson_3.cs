using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    // ============================================================
    // ZMIENNE
    // ============================================================
    // Zmienna przechowuje wartość określonego typu.
    // Nazwa powinna jasno określać, co reprezentuje.
    //
    // Lokalne zmienne -> camelCase
    // Prywatne pola   -> _camelCase
    // Stałe           -> PascalCase
    // ============================================================

    private const int RepetitionCount = 2;
    private int _jumpCount = 0;

    void Start()
    {
        // Zmienna lokalna istnieje tylko w obrębie tej metody.
        int totalJumps = GetDoubleRepetitionCount();

        for (int i = 0; i < totalJumps; i++)
        {
            Jump();
        }
    }
// ============================================================
    // METODY
    // ============================================================
    // Metoda to wydzielony fragment kodu realizujący określoną
    // funkcjonalność / odpowiedzialność.
    //
    // Dobra metoda:
    // - ma jasno określone zadanie,
    // - posiada opisową nazwę,
    // - powinna być możliwie krótka,
    // - może przyjmować parametry,
    // - może zwracać wartość.
    //
    // Nazwy metod -> PascalCase
    // ============================================================

    // Metoda typu void — wykonuje operację,
    // ale nie zwraca wartości.
    private void Jump()
    {
        _jumpCount++;
        Debug.Log("Jump");
    }


    // Metoda zwracająca wartość typu int.
    // return przekazuje wynik do miejsca wywołania.
    private int GetDoubleRepetitionCount()
    {
        return RepetitionCount * 2;
    }

    // ============================================================
    // PARAMETRY
    // ============================================================
    // Parametr to dane wejściowe przekazywane do metody.
    //
    // damage -> parametr
    // 10     -> argument
    // ============================================================

    private void TakeDamage(int damage)
    {
        // damage jest dostępne tylko wewnątrz tej metody.
        Debug.Log($"Damage: {damage}");
    }
}

// ============================================================
    // KOMENTARZE
    // ============================================================
    // Komentarz powinien wyjaśniać przede wszystkim:
    // "DLACZEGO?", a nie "CO ROBI KOD".
    // komentarze zostawiamy dla siebie nie push-emy na gotowy produkt
    // =============================================================

