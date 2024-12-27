namespace usermanagement_api.Utilities;

public class ApiRoute
{
    const string Root = "api";
    const string Version = "1";
    const string Base = Root + "/" + Version;

    internal static class general
    {
        const string Route = Base + "/general/";
        internal const string checkhealth = Route + "checkhealth";
    }

    internal static class users
    {
        const string Route = Base + "/users/";
        internal const string getusers = Route + "getusers";
        internal const string getuserbyid = Route + "getuserbyid";
        internal const string registeruser = Route + "registeruser";
        internal const string loginbyusername = Route + "loginbyusername";
        internal const string loginbyemail = Route + "loginbyemail";
    }

    internal static class workorders
    {
        const string Route = Base + "/workorders/";
        internal const string getworkorders = Route + "getworkorders";
    }

    internal static class assets
    {
        const string Route = Base + "/assets/";
        internal const string getassets = Route + "getassets";
    }
}
