using System.Collections.Generic;
using Defectively;

namespace DefectivelyClient.Management
{
    public static class Luva
    {
        public static bool CheckValue(this List<string> values, string value) {
            var Result = values.Contains("luva.wildcard") || values.Contains(value);
            if (!Result) {
                Report(value);
            }
            return Result;
        }

        public static bool CheckValueSilently(this List<string> values, string value) {
            return values.Contains("luva.wildcard") || values.Contains(value);
        }

        public static void Report(string value) {
            Defectively.Extension.ExtensionPool.Client.SendPacketToServer(string.Join("|", Enumerations.Action.SendLuvaNotice, value));
        }
    }
}
