using Pds.Core.Enums;
namespace Pds.Web.Common;

public class ContactBuilder
{
    public static string ToLink(ContactType? type, string contact)
    {
        return type switch
        {
            ContactType.Other => contact,
            ContactType.Telegram => $"<a href=\"https://t.me/{contact}\" target=\"_blank\">{contact}</a>",
            ContactType.WhatsApp => contact,
            ContactType.Instagram => $"<a href=\"https://instagram.com/{contact}\" target=\"_blank\">{contact}</a>",
            ContactType.Phone => contact,
            _ => contact
        };
    }
}