using Pds.Core.Enums;
namespace Pds.Web.Common;

public static class EnumsTranslator
{
    public static string ContentTypeToRu(ContentType type)
    {
        return type switch
        {
            ContentType.Other => "Прочее",
            ContentType.Post => "Пост",
            ContentType.Story => "Сториз",
            ContentType.Integration => "Интеграция",
            ContentType.SponsoredVideo => "Спонс. видео",
            ContentType.EventHosting => "Ведущий",
            ContentType.EventParticipation => "Докладчик",
            ContentType.Exclusive => "Эксклюзив",
            ContentType.Preroll => "Преролл",
            _ => string.Empty
        };
    }
    
    public static string GiftTypeToRu(GiftType type)
    {
        return type switch
        {
            GiftType.Other => "Прочее",
            GiftType.Stickers => "Стикера",
            GiftType.Book => "Книга",
            _ => string.Empty
        };
    }

    public static string GiftStatusToRu(GiftStatus status)
    {
        return status switch
        {
            GiftStatus.New => "Новый",
            GiftStatus.Raffled => "Разыгран",
            GiftStatus.Waiting => "Готов к отправке",
            GiftStatus.Strange => "Странный",
            GiftStatus.Completed => "Завершен",
            _ => string.Empty
        };
    }
    
    public static string PersonStatusToRu(PersonStatus status)
    {
        return status switch
        {
            PersonStatus.Active => "Активный",
            PersonStatus.Archived => "Архивный",
            _ => string.Empty
        };
    }
    
    public static string BillStatusToRu(BillStatus status)
    {
        return status switch
        {
            BillStatus.Active => "Активный",
            BillStatus.Archived => "Архивный",
            _ => string.Empty
        };
    }
    
    public static string CostStatusToRu(CostStatus status)
    {
        return status switch
        {
            CostStatus.Active => "Активный",
            CostStatus.Archived => "Архивный",
            _ => string.Empty
        };
    }
    
    public static string ClientStatusToRu(ClientStatus status)
    {
        return status switch
        {
            ClientStatus.Active => "Активный",
            ClientStatus.Archived => "Архивный",
            _ => string.Empty
        };
    }

    public static string SocialMediaTypeToRu(SocialMediaType type)
    {
        return type switch
        {
            SocialMediaType.Other => "Прочее",
            SocialMediaType.YouTube => "YouTube",
            SocialMediaType.Instagram => "Instagram",
            SocialMediaType.Telegram => "Telegram",
            SocialMediaType.Clubhouse => "Clubhouse",
            SocialMediaType.TikTok => "TikTok",
            SocialMediaType.Vkontakte => "ВКонтакте",
            _ => string.Empty
        };
    }

    public static string ContactTypeToRu(ContactType? type)
    {
        return type switch
        {
            ContactType.Other => "Прочее",
            ContactType.Telegram => "Telegram",
            ContactType.WhatsApp => "WhatsApp",
            ContactType.Instagram => "Instagram",
            ContactType.Phone => "Телефон",
            _ => string.Empty
        };
    }

    public static string PaymentTypeToRu(PaymentType? type)
    {
        return type switch
        {
            PaymentType.Other => "Прочее",
            PaymentType.BankAccount => "Юр. счёт",
            PaymentType.PersonalAccount => "Личный счёт",
            PaymentType.Crypto => "Крипта",
            PaymentType.Barter => "Бартер",
            PaymentType.Cash => "Наличные",
            _ => string.Empty
        };
    }

    public static string PaymentTypeToShortRu(PaymentType? type)
    {
        return type switch
        {
            PaymentType.Other => "дрг",
            PaymentType.BankAccount => "юр",
            PaymentType.PersonalAccount => "лчн",
            PaymentType.Crypto => "крп",
            PaymentType.Barter => "брт",
            PaymentType.Cash => "нал",
            _ => string.Empty
        };
    }

    public static string CostTypeToRu(CostType? type)
    {
        return type switch
        {
            CostType.Other => "Прочее",
            CostType.Equipment => "Оборудование",
            CostType.Movement => "Транспорт",
            CostType.Accommodation => "Жильё",
            CostType.Service => "Услуги",
            CostType.Subscription => "Подписка",
            CostType.Rent => "Аренда",
            _ => string.Empty
        };
    }

    public static string BillTypeToRu(BillType? type)
    {
        return type switch
        {
            BillType.Other => "Прочее",
            BillType.Content => "Контент",
            BillType.Donation => "Донаты",
            BillType.Resale => "Перепродажа",
            BillType.Adsense => "AdSense",
            _ => string.Empty
        };
    }
}