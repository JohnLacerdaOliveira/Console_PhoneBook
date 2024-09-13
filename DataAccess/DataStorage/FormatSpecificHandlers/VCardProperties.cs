internal static class VCardProperties
{
    public static Dictionary<string, string> Map { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "FN", "Name" },
        { "NICKNAME", "Nickname" },
        { "TEL", "PhoneNumber" },
        { "EMAIL", "Email" },
        { "BDAY", "BirthDay" },
        { "ADR", "Address" },
        { "ORG", "Organization" },
        { "TITLE", "Title" },
        { "ROLE", "Role" },
        { "NOTE", "Note" },
    };

    //TODO - Continue implementation for diferent contact properties implementation
    public static Dictionary<string,Func<string,object?>> convertToType { get; } = new Dictionary<string, Func<string, object?>>()
    {
        { "BDAY", ConvertToDateTime},
        { "REV", ConvertToDateTime}
    };

    static Func<string, object?> ConvertToDateTime = d =>
    {
        if (DateTime.TryParse(d, out DateTime dateTime))
        {
            return dateTime;

        }
        return null;
    };
}
