namespace Pds.Core.Enums;

public enum PaymentType
{
    Other = 0,          // Прочий тип оплаты
    Cash = 1,           // Наличные
    Barter = 2,         // Бартер
    BankAccount = 3,    // На счёт юридического лица
    PersonalAccount = 4,// На счёт физического лица
    Crypto = 5,         // Криптовалюты и токены
}