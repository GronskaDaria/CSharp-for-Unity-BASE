using System;
using UnityEngine;

// ============================================================
// LESSON 5 – CLASSES, OBJECTS, INHERITANCE, ACCESS MODIFIERS
// ============================================================

// 1. CLASS AND OBJECT (INSTANCE)
// ------------------------------------------------------------
// Class – szablon (blueprint) definiujący strukturę i zachowanie
// obiektów. Określa pola, właściwości i metody.
//
// Object / Instance – konkretna instancja utworzona na podstawie
// definicji klasy.
//
// Jedna klasa może posiadać wiele niezależnych instancji.
// Każda instancja posiada własny stan (wartości pól).
//
// W Unity pracujemy na instancjach skryptów przypisanych do
// GameObject, a nie na samych plikach .cs.
//
// MonoBehaviour – klasa bazowa dla komponentów Unity.
// Tylko komponenty dziedziczące po MonoBehaviour można
// bezpośrednio dodawać do GameObject.
//
// Zwykła klasa wykorzystywana np. do
// przechowywania danych i implementowania logiki.
//
// ScriptableObject – klasa Unity służąca do tworzenia
// współdzielonych zasobów danych (assets), niezależnych
// od GameObject.
//
// Inicjalizacja:
// - MonoBehaviour – instancją zarządza Unity.
// - Zwykła klasa – instancję tworzymy za pomocą operatora new.
// - ScriptableObject – tworzymy przez CreateInstance lub jako asset.
//
// Nie możemy tworzyć instancji MonoBehaviour za pomocą new.
// ------------------------------------------------------------
// [Serializable] – pozwala systemowi serializacji Unity
// zapisywać i odtwarzać dane tej klasy.
//
// Zwykłe klasy mogą być wyświetlane w Inspectorze, jeśli
// spełniają wymagania serializacji Unity.

public class Lesson5 : MonoBehaviour
{
    // [SerializeField] – udostępnia prywatne pole w Inspectorze,
    // bez zmiany modyfikatora dostępu.
    //
    // Unity obsługuje serializację m.in. typów prostych,
    // tablic, list i klas oznaczonych [Serializable].
    //
    // Nie każde pole można serializować.
    // Przykładowo pola static i właściwości nie są
    // serializowane przez standardowy system Unity.

    /*[SerializeField] private int _a = 10;
    [SerializeField] private int _b = 20;*/

    // Pojedyncza instancja klasy BaseClass.
    [SerializeField] private BaseClass _character;

    // Tablica instancji klasy BaseClass.
    [SerializeField] private BaseClass[] _characters;

    // --------------------------------------------------------
    // ACCESS MODIFIERS
    // --------------------------------------------------------
    // Modyfikatory dostępu określają widoczność elementów klasy.
    //
    // public             – dostęp z dowolnego miejsca.
    // private            – dostęp tylko wewnątrz danej klasy.
    // protected          – dostęp w klasie i klasach pochodnych.
    // internal           – dostęp w obrębie tego samego assembly.
    // protected internal – dostęp w tym samym assembly lub klasach
    //                      pochodnych.
    // private protected  – dostęp w klasach pochodnych w tym samym
    //                      assembly.
    //
    // Dobra praktyka:
    // Stosuj zasadę minimalnego dostępu (Encapsulation).
    // Pola powinny być domyślnie private.
    // Dostęp do nich udostępniaj przez właściwości lub metody.
    //
    // [SerializeField] private int _health;
    // Pole jest prywatne, ale widoczne w Inspectorze.

    // --------------------------------------------------------
    // STATIC
    // --------------------------------------------------------
    // static – element należy do klasy, a nie do konkretnej instancji.
    //
    // Elementy statyczne:
    // - Nie wymagają utworzenia instancji klasy.
    // - Są współdzielone przez wszystkie instancje klasy.
    // - Wywołujemy je przez nazwę klasy.
    //
    // Przykład:
    // BaseClass.CalculateTotalMoney(100, 200);
    //
    // Zasady:
    // - static może dotyczyć pól, metod i właściwości.
    // - Metoda static nie ma bezpośredniego dostępu do pól
    //   i metod instancyjnych.
    // - Klasa static nie może być instancjonowana ani dziedziczona.
    // - Elementy static nie są serializowane przez standardowy
    //   system serializacji Unity.
    //
    // UWAGA:
    // Nie wszystko w klasie powinno być static!
    // Używamy static, gdy dane lub funkcjonalność mają być
    // wspólne dla całej klasy, a nie konkretnego obiektu.

    private void Start()
    {
        // ----------------------------------------------------
        // OBJECT INITIALIZATION
        // ----------------------------------------------------
        // Zwykłą klasę inicjalizujemy operatorem new.
        //
        // Każde wywołanie new tworzy nową, niezależną instancję.

        BaseClass character1 = new BaseClass();
        BaseClass character2 = new BaseClass();

        character1.money = 200;
        character2.money = 500;

        // Każda instancja posiada własne wartości pól.
        Debug.Log(character1.money);
        Debug.Log(character2.money);

        // ----------------------------------------------------
        // ACCESS TO CLASS MEMBERS
        // ----------------------------------------------------
        // Dostęp do publicznych pól i właściwości odbywa się
        // przez operator kropki (.).

        character1.Hp = 80;
        character1.TakeDamage(20);

        Debug.Log(character1.Hp);

        // ----------------------------------------------------
        // SERIALIZED CLASS IN UNITY INSPECTOR
        // ----------------------------------------------------
        // _character i _characters są przypisywane przez Inspector.
        // Nie musimy tworzyć ich ręcznie, jeśli Unity odtworzyło
        // ich dane z serializowanych wartości.

        if (_character != null)
        {
            Debug.Log(_character.Hp);
        }

        // ----------------------------------------------------
        // STATIC METHOD
        // ----------------------------------------------------
        // Metodę statyczną wywołujemy bez tworzenia instancji.

        int totalMoney = BaseClass.CalculateTotalMoney(
            character1.money,
            character2.money
        );

        Debug.Log(totalMoney);

        // ----------------------------------------------------
        // ADD COMPONENT
        // ----------------------------------------------------
        // Komponent dziedziczący po MonoBehaviour można dodać
        // do GameObject za pomocą AddComponent<T>().
        //
        // Nie używamy operatora new do tworzenia MonoBehaviour.
        //
        // Przykład:
        // Lesson5 newComponent = gameObject.AddComponent<Lesson5>();
    }

    // ========================================================
    // 4. GET COMPONENT
    // ========================================================
    // Metody pobierania komponentów Unity:
    //
    // GetComponent<T>()
    // - Pobiera komponent z aktualnego GameObject.
    //
    // GetComponentInChildren<T>()
    // - Wyszukuje komponent w obiektach potomnych.
    //
    // GetComponentInParent<T>()
    // - Wyszukuje komponent w obiektach nadrzędnych.
    //
    // FindObjectOfType<T>()
    // - Starsze API wyszukujące obiekt danego typu w scenie.
    // - W nowszych wersjach Unity dostępne są m.in.
    //   FindFirstObjectByType<T>() i FindAnyObjectByType<T>().
    //
    // Przykłady:
    //
    // Lesson5 component = GetComponent<Lesson5>();
    // Lesson5 child = GetComponentInChildren<Lesson5>();
    // Lesson5 parent = GetComponentInParent<Lesson5>();
    //
    // UWAGI DOTYCZĄCE WYDAJNOŚCI:
    // - Wyszukiwanie komponentów generuje dodatkowy koszt.
    // - Unikaj niepotrzebnego wyszukiwania w każdej klatce Update().
    // - Referencje najlepiej pobierać np. w Awake() lub Start().
    // - Przechowuj pobrane referencje w polach klasy.
    // - FindObjectOfType i podobne metody wyszukujące mogą być
    //   kosztowne i nie powinny być nadużywane.
}


// ============================================================
// 5. INHERITANCE – INHERITANCE OF CLASSES
// ============================================================
// Dziedziczenie pozwala tworzyć klasy pochodne na podstawie
// istniejących klas.
//
// Base Class – klasa bazowa.
// Derived Class – klasa pochodna.
//
// Klasa pochodna może korzystać z dostępnych elementów
// klasy bazowej oraz rozszerzać jej funkcjonalność.
//
// C# obsługuje dziedziczenie po jednej klasie bazowej.
// Możliwe jest implementowanie wielu interfejsów.
//
// Przykład koncepcyjny:
// public class AdvancedCharacter : BaseClass
// {
//     // Rozszerzenie funkcjonalności BaseClass.
// }
//
// UWAGA:
// BaseClass nie musi dziedziczyć po MonoBehaviour.
// Zwykłe klasy mogą dziedziczyć po innych zwykłych klasach.
// Dziedziczenie po MonoBehaviour jest stosowane dla komponentów Unity.
