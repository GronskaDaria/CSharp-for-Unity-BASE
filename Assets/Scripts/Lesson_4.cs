using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    // ARRAY — kolekcja o stałej długości.
    // [SerializeField] pozwala konfigurować dane w Inspectorze.
    [SerializeField] private int[] numbers;

    // Inicjalizacja tablicy wartościami początkowymi.
    private int[] _numbers2 = new int[] { 1, 2, 3, 4, 5 };

    // LIST<T> — kolekcja o zmiennej liczbie elementów.
    // Wymaga przestrzeni nazw System.Collections.Generic.
    private List<int> _listOfNumbers = new List<int>();

    private void Start()
    {
        // FOR — iteracja z kontrolą indeksu.
        // Length określa liczbę elementów tablicy.
        for (int i = 0; i < _numbers2.Length; i++)
        {
            Debug.Log(_numbers2[i]); // Odczyt elementu o indeksie i.
        }

        // FOREACH — iteracja po elementach bez obsługi indeksu.
        foreach (int number in _numbers2)
        {
            Debug.Log(number);
        }

        // LIST OPERATIONS
        _listOfNumbers.Add(10);      // Dodaje element na końcu.
        _listOfNumbers.Add(20);
        _listOfNumbers.Insert(1, 15); // Wstawia element pod indeksem 1.

        _listOfNumbers.Remove(20);   // Usuwa pierwsze wystąpienie wartości.
        _listOfNumbers.RemoveAt(0);  // Usuwa element pod indeksem 0.

        Debug.Log(_listOfNumbers.Count); // Liczba elementów listy.

        _listOfNumbers.Clear();      // Usuwa wszystkie elementy.
    }
}

/*
NOTES
------------------------------------------------------------

1. ARRAY vs LIST
   - Array: stała długość, dostęp przez indeks, właściwość Length.
   - List<T>: zmienna liczba elementów, właściwość Count.
   - Wybór zależy od wymagań, a nie od zasady "tablica zawsze szybsza".

2. INDEXING
   - Indeksy zaczynają się od 0.
   - Poprawny zakres: 0 .. Count - 1 (dla List<T>).
   - RemoveAt(5) wymaga co najmniej 6 elementów.
   - Niepoprawny indeks powoduje ArgumentOutOfRangeException.

3. LOOP SAFETY
   - for: gdy potrzebujesz indeksu lub kontrolujesz przebieg iteracji.
   - foreach: gdy chcesz odczytać kolejne elementy.
   - while: wykonuje się, dopóki warunek jest prawdziwy.
   - do-while: wykonuje ciało przynajmniej raz.
   - Modyfikowanie listy podczas foreach może wywołać wyjątek.

4. UNITY INSPECTOR
   - [SerializeField] udostępnia prywatne pole w Inspectorze.
   - Tablica może być nieprzypisana (null).
   - Sprawdź dane przed iteracją, jeśli mogą nie być ustawione.

5. PERFORMANCE & DESIGN
   - Nie wybieraj List<T> wyłącznie dlatego, że można ją edytować.
   - Unikaj niepotrzebnych operacji i alokacji w Update().
   - Stosuj nazwy opisujące zawartość, np. enemyHealthValues.
   - Usuń nieużywane usingi; kod powinien być czytelny i celowy.

6. DEBUGGING
   - Debug.Log(numbers2.Length) wypisuje długość tablicy,
     a Debug.Log(numbers2[i]) wypisuje konkretny element.
   - Przed RemoveAt(index) upewnij się, że indeks jest poprawny.
*/


       
       