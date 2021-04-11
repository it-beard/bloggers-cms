using Pds.Core.Enums;

namespace Pds.Web.Common
{
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
                _ => string.Empty
            };
        }

        public static string ContactTypeToRu(ContactType type)
        {
            return type switch
            {
                ContactType.Other => "Прочее",
                ContactType.Telegram => "Telegram",
                ContactType.WhatsApp => "WhatsApp",
                ContactType.Instagram => "Instagram",
                ContactType.Email => "Емейл",
                ContactType.Phone => "Телефон",
                _ => string.Empty
            };
        }

        public static string PaymentTypeToRu(PaymentType? type)
        {
            return type switch
            {
                PaymentType.Other => "Прочее",
                PaymentType.BankAccount => "ИП",
                PaymentType.Tinkoff => "Тинькофф",
                PaymentType.Yoomoney => "ЮМани",
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
                PaymentType.BankAccount => "ип",
                PaymentType.Tinkoff => "тин",
                PaymentType.Yoomoney => "юмн",
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
                BillType.Content => "Конент",
                BillType.Donation => "Донаты",
                BillType.Resale => "Перепродажа",
                BillType.Adsense => "AdSense",
                _ => string.Empty
            };
        }
    }
}