namespace Pds.Core.Enums;

public enum GiftStatus
{
    New = 0,        // Новый, не разыгранный подарок
    Raffled = 1,    // Разыгран
    Waiting = 2,    // Ожидает доставки
    Completed = 3,  // Отправлен (архивный, готов)
    Strange = 4     // Странный (потеряшка или перенос или еще чего)
}