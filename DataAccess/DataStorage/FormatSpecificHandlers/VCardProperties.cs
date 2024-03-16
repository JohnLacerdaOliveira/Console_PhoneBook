internal static class VCardProperties
{
    public static Dictionary<string, string> Map { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "FN", "FormattedName" },
        { "N", "Name" },
        { "TEL", "PhoneNumber" },
        { "EMAIL", "Email" },
        { "NICKNAME", "Nickname" },
        { "PHOTO", "Photograph" },
        { "BDAY", "Birthday" },
        { "ADR", "Address" },
        { "LABEL", "Label" },
        { "MAILER", "EmailProgram" },
        { "TZ", "TimeZone" },
        { "GEO", "GeographicPosition" },
        { "TITLE", "Title" },
        { "ROLE", "Role" },
        { "LOGO", "Logo" },
        { "AGENT", "Agent" },
        { "ORG", "Organization" },
        { "NOTE", "Note" },
        { "REV", "RevisionTimestamp" },
        { "UID", "UniqueIdentifier" },
        { "URL", "URL" }
    };
}
