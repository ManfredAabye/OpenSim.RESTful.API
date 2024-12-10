public static class CommandParser
{
    public static string BuildRegionShowCommand(string regionName)
    {
        return $"show region \"{regionName}\"";
    }
}