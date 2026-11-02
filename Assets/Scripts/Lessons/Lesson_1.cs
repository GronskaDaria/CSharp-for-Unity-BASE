using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    /* C# — podstawowe typy zmiennych
     int — liczby całkowite, np. 5, 100, -3.
     float — liczby zmiennoprzecinkowe. W C# używamy kropki i sufiksu f, np. 39.2f.
     string — tekst zapisany w cudzysłowie, np. "Cat".
     bool — wartość logiczna: true albo false.
     var — pozwala kompilatorowi automatycznie wywnioskować typ zmiennej. Typ jest ustalany podczas kompilacji i później się nie zmienia.
         Uwaga: var stosujemy głównie dla zmiennych lokalnych, np. wewnątrz metod. Nie używamy private var dla pól klasy.*/

    private int _catAge = 5;
    private string _catName = "Cat";
    private float _catTemperature = 39.2f;
    private bool _catIsAlive = true;

    private void Start()
    {
        var nextAge = _catAge + 1; 
        Debug.Log(_catName); 
        Debug.Log(_catTemperature); 
        Debug.Log(_catIsAlive); 
        Debug.Log(nextAge);
    }
}