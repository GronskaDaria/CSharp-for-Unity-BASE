using UnityEngine;

// ============================================================
// LESSON 6 – NAMING CONVENTIONS
// ============================================================

// 1. NAMING CONVENTIONS
// ------------------------------------------------------------
// Naming conventions – zasady nazewnictwa elementów kodu.
// Zapewniają spójność, czytelność i łatwiejsze utrzymanie projektu.
//
// PascalCase – każde słowo rozpoczyna się wielką literą.
// Przykład: PlayerController, CalculateDamage.
//
// camelCase – pierwsze słowo rozpoczyna się małą literą,
// kolejne słowa rozpoczynają się wielką literą.
// Przykład: playerHealth, calculateDamage.
//
// ------------------------------------------------------------
// 2. NAMING RULES – ELEMENTS NAMING
// ------------------------------------------------------------
//
// CLASS (public/private) – PascalCase
// Przykład: PlayerController, BaseClass.
//
// DELEGATES (public/private) – PascalCase
// Przykład: DamageHandler, PlayerAction.
//
// EVENTS (public/private) – PascalCase
// Przykład: OnPlayerDeath, HealthChanged.
//
// STRUCTS (public/private) – PascalCase
// Przykład: PlayerStats, CharacterData.
//
// INTERFACES (public/private) – IPascalCase
// Nazwa rozpoczyna się od litery I.
// Przykład: IDamageable, IMovable.
//
// PUBLIC VARIABLES – PascalCase
// Przykład: PlayerHealth, MovementSpeed.
//
// PRIVATE VARIABLES – _camelCase
// Przykład: _playerHealth, _movementSpeed.
//
// SERIALIZED PRIVATE VARIABLES – camelCase
// [SerializeField] private int playerHealth;
// [SerializeField] private float movementSpeed;
//
// BOOL VARIABLES – Is / Has / Can / Should
// Zachowują konwencję właściwą dla poziomu dostępu:
// public bool IsAlive;
// private bool _isAlive;
// [SerializeField] private bool canMove;
//
// STATIC VARIABLES:
// Public static – PascalCase.
// Przykład: public static int PlayerCount;
//
// Private static – s_camelCase.
// Przykład: private static int s_playerCount;
//
// CONST VARIABLES (public/private) – PascalCase
// Przykład: MaxHealth, DefaultSpeed.
//
// METHODS – PascalCase
// Przykład: CalculateDamage(), TakeDamage().
//
// METHOD PARAMETERS – camelCase
// Przykład: damageAmount, targetPosition.
//
// LOCAL VARIABLES – camelCase
// Przykład: currentHealth, totalDamage.
//
// ============================================================
// 3. NAMING EXAMPLES – LESSON6
// ============================================================

public class Lesson6 : MonoBehaviour
{
    // Public fields – PascalCase.
    public int PlayerLevel;

    // Private fields – _camelCase.
    private int _playerHealth;

    // Serialized private fields – _camelCase.
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAlive;

    // Public static – PascalCase.
    public static int PlayerCount;

    // Private static – s_camelCase.
    private static int s_instanceCount;

    // Constants – PascalCase.
    private const int MaxHealth = 100;
    private const float DefaultSpeed = 5f;

    // Methods – PascalCase.
    // Parameters – camelCase.
    private void TakeDamage(int damageAmount)
    {
        _playerHealth -= damageAmount;
    }

    private int CalculateHealth(int currentHealth)
    {
        return currentHealth + MaxHealth;
    }

    private void Start()
    {
        // Local variables – camelCase.
        int currentLevel = PlayerLevel;
        bool isPlayerAlive = isAlive;
    }
}
// ========================================================
    // 4. CLEAN CODE – CODE QUALITY
    // ========================================================
    //
    // Clean Code – podejście do tworzenia kodu, którego celem
    // jest czytelność, prostota, przewidywalność i łatwość
    // utrzymania oraz rozwijania projektu.
    //
    // NAJWAŻNIEJSZE ZASADY:
    //
    // 1. Meaningful Names
    // Stosuj opisowe nazwy zmiennych, metod i klas.
    // Nazwa powinna komunikować przeznaczenie elementu.
    //
    // 2. Avoid Magic Numbers
    // Unikaj nieopisanych wartości liczbowych bezpośrednio
    // w logice programu.
    //
    // Zamiast:
    // _playerHealth -= 25;
    //
    // Lepiej:
    // const int DamageAmount = 25;
    // _playerHealth -= DamageAmount;
    //
    // Wartości konfiguracyjne w Unity można również udostępniać
    // przez [SerializeField].
    //
    // 3. Comments
    // Nie komentuj oczywistych instrukcji.
    //
    // 4. Encapsulation
    // Ograniczaj publiczny dostęp do pól i metod.
    // Stosuj private oraz kontrolowany dostęp przez Properties.
    //
    // 5. Single Responsibility
    // Każda metoda powinna realizować jedno konkretne zadanie.
    // Unikaj metod wykonujących wiele niezależnych operacji.
    //
    // 6. Keep It Simple
    // Unikaj niepotrzebnej komplikacji kodu.
    // Wybieraj proste i czytelne rozwiązania.
    //
    // 7. Code Reusability
    // Unikaj powielania tego samego kodu.
    // Wydzielaj powtarzalną logikę do metod.
    //
    // 8. Refactoring
    // Refaktoryzacja – poprawianie wewnętrznej struktury kodu
    // bez zmiany jego zewnętrznego zachowania.
    //
    // Przykłady:
    // - zmiana nazw na bardziej opisowe,
    // - wydzielanie metod,
    // - usuwanie powtarzalnego kodu,
    // - upraszczanie warunków,
    // - poprawianie struktury klas.
    //
    // 9. Readability
    // Pisz kod krótko i precyzyjnie, ale tak, aby można było
    // łatwo zrozumieć go i zmodyfikować po dłuższym czasie.
    //
    // 10. Avoid Premature Optimization
    // Nie optymalizuj kodu na podstawie przypuszczeń.
    // Najpierw identyfikuj rzeczywiste problemy wydajnościowe.

    // ========================================================
    // 5. SOFTWARE DESIGN PRINCIPLES
    // ========================================================
    //
    // SOLID – zestaw pięciu zasad projektowania
    // obiektowego, ułatwiających tworzenie elastycznego
    // i łatwego w utrzymaniu oprogramowania.
    //
    // S – SINGLE RESPONSIBILITY PRINCIPLE
    // Single Responsibility – jedna klasa powinna mieć
    // jedną główną odpowiedzialność i jeden zasadniczy powód
    // do zmiany.
    //
    // O – OPEN/CLOSED PRINCIPLE
    // Open/Closed – elementy oprogramowania powinny być otwarte
    // na rozszerzanie, ale zamknięte na niepotrzebne modyfikacje.
    //
    // L – LISKOV SUBSTITUTION PRINCIPLE
    // Liskov Substitution – obiekt klasy pochodnej powinien
    // móc zastąpić obiekt klasy bazowej bez zaburzania
    // poprawności działania programu.
    //
    // I – INTERFACE SEGREGATION PRINCIPLE
    // Interface Segregation – lepiej tworzyć mniejsze,
    // wyspecjalizowane interfejsy niż jeden rozbudowany interfejs
    // wymuszający implementowanie niepotrzebnych metod.
    //
    // D – DEPENDENCY INVERSION PRINCIPLE
    // Dependency Inversion – moduły wysokiego poziomu nie powinny
    // zależeć bezpośrednio od szczegółów implementacji modułów
    // niskiego poziomu. Oba powinny zależeć od abstrakcji.
    //
    // --------------------------------------------------------
    // ADDITIONAL PRINCIPLES
    // --------------------------------------------------------
    //
    // KISS – KEEP IT SIMPLE, STUPID
    // Projektuj rozwiązania w możliwie prosty sposób.
    // Unikaj niepotrzebnej złożoności.
    //
    // DRY – DON'T REPEAT YOURSELF
    // Nie powielaj tej samej logiki w wielu miejscach.
    // Wydzielaj wspólne funkcjonalności.