using System;
using UnityEngine;

[Serializable]
public class BaseClass
{
    // Public – dostęp z innych klas.
    public int money = 100;

    // Private – dostęp wyłącznie wewnątrz BaseClass.
    private int _hp = 100;

    private int _mp = 50;

    private int _speed = 10;

    // Property – kontrolowany dostęp do prywatnego pola.
    // get – odczyt wartości.
    // set – przypisanie nowej wartości.

    public int Hp
    {
        get { return _hp; }
        set { _hp = Mathf.Max(0, value); }
    }

    public int Mp
    {
        get { return _mp; }
        set { _mp = Mathf.Max(0, value); }
    }

    public int Speed
    {
        get { return _speed; }
        set { _speed = Mathf.Max(0, value); }
    }

    // Metoda instancyjna – działa na danych konkretnego obiektu.
    public void TakeDamage(int damage)
    {
        Hp -= damage;
    }

    // Metoda statyczna – należy do klasy, nie do instancji.
    // Nie wymaga utworzenia obiektu BaseClass.
    public static int CalculateTotalMoney(int first, int second)
    {
        return first + second;
    }
}


