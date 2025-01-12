namespace usermanagement_api.Attributes
{
    // Attribute to skip token validation for specific endpoints
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
    public class AllowAnonymousTokenAttribute : Attribute
    {
        // This attribute does not need any logic in this case.
        // It's used to mark endpoints where token validation should be skipped.
    }
}
