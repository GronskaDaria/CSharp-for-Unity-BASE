using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    private bool _isCatAlive = true;
    private float _catAge = 0.7f;
    private string _catName = "Cat";
    private string _catMood = "Happy";

    void Start()
    {
        // IF / ELSE
        // if sprawdza warunek i wykonuje kod, gdy warunek jest true.
        // Operatory logiczne:
        // && (AND) – oba warunki muszą być true
        // || (OR)  – wystarczy, że jeden warunek jest true
        // !  (NOT) – odwraca wartość logiczną
        //
        // Priorytet: ! → && → ||
        // Nawiasy () pozwalają jawnie określić kolejność sprawdzania.

        if (_isCatAlive && _catAge < 0.6f)
        {
            Debug.Log("It is a little kitty");
        }
        else if (_isCatAlive && _catAge < 1f)
        {
            Debug.Log("It is a Cat Junior");
        }
        else
        {
            Debug.Log("It is an adult cat");
        }


        // SWITCH
        // switch sprawdza wartość zmiennej i wybiera pasujący case.
        // case – definiuje konkretną wartość do sprawdzenia.
        // break – kończy wykonanie danego case.
        // default – wykonuje się, gdy żaden case nie pasuje.
        //
        // IF → sprawdzanie warunków
        // SWITCH → wybór na podstawie konkretnej wartości

        switch (_catMood)
        {
            case "Happy":
                Debug.Log("The cat is happy!");
                break;

            case "Hungry":
                Debug.Log("The cat is hungry!");
                break;

            case "Sleepy":
                Debug.Log("The cat wants to sleep.");
                break;

            case "Angry":
                Debug.Log("The cat is angry!");
                break;

            default:
                Debug.Log("The cat's mood is unknown.");
                break;
        }
    }
}
// ============================================================
// PODSUMOWANIE. Krótka notatka
// ============================================================

// 1. SHORT-CIRCUIT EVALUATION
// && oraz || mogą zatrzymać sprawdzanie warunku wcześniej.
//
// && → jeśli lewa strona jest false, prawa nie jest sprawdzana.
// || → jeśli lewa strona jest true, prawa nie jest sprawdzana.
//
// Przykład:
// if (_isCatAlive && _catAge < 1f)
//
// Jeśli _isCatAlive == false, Unity nie musi sprawdzać drugiego warunku.
//
// Jest to ważne, gdy druga część warunku wykonuje metodę,
// odwołuje się do obiektu lub może powodować NullReferenceException.


// 2. OPERATOR PRECEDENCE
// Kolejność operatorów ma wpływ na wynik całego warunku.
//
// !  → NOT
// && → AND
// || → OR
//
// Dla złożonych warunków używaj nawiasów:
// if ((_isCatAlive && _catAge < 1f) || _catName == "Cat")
//
// Nawiasy zwiększają czytelność i zmniejszają ryzyko błędnej interpretacji.


// 3. AVOID OVERLY COMPLEX CONDITIONS
// Jeśli warunek staje się trudny do przeczytania,
// warto rozbić go na mniejsze, nazwane warunki.
//
// Zamiast:
// if (_isCatAlive && _catAge < 1f && _catMood == "Happy" && ...)
//
// można użyć:
// bool isYoungCat = _catAge < 1f;
// bool canInteract = _isCatAlive && isYoungCat;
//
// Dzięki temu kod jest łatwiejszy do debugowania i utrzymania.


// 4. IF vs SWITCH
// IF → warunki, zakresy, relacje i złożona logika.
//
// SWITCH → wybór jednej ścieżki na podstawie wartości.
//
// Przykład:
// if (_catAge < 1f)
//
// switch (_catMood)


// 5. BREAK IN SWITCH
// break kończy aktualny case.
// Bez break kod może kontynuować wykonanie kolejnych przypadków
// (z wyjątkami wynikającymi z konstrukcji switch w C#).


// 6. DEFAULT
// default obsługuje wartości, których nie przewidzieliśmy.
//
// W praktycznym kodzie jest to zabezpieczenie przed nieobsługiwanym stanem.
//
// Szczególnie przydatne, gdy wartość pochodzi np. z:
// - danych gracza
// - konfiguracji
// - save'a
// - enumów
// - systemu zewnętrznego


// 7. UNITY — UPDATE vs START
// Warunki w Start() wykonują się raz, podczas inicjalizacji obiektu.
//
// Nie należy bez potrzeby umieszczać podobnej logiki w Update(),
// ponieważ Update() wykonuje się każdą klatkę.
//
// Jeśli warunek musi być sprawdzany ciągle,
// dopiero wtedy rozważ umieszczenie go w Update()
// lub zastosowanie eventów / innych mechanizmów reaktywnych.
