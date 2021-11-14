namespace Pds.Core.Enums;

public enum GiftStatus
{
    New = 0,                // Новый, не разыгранный подарок
    Raffled = 1,            // Разыгран
    WaitingForDelivery = 2, // Готов к отправке
    Lost = 3,               // Утерян (потеряшка)
    Postponed = 4,          // Перенесен
    Completed = 5           // Отправлен (архивный)
}