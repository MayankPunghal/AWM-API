namespace usermanagement_api.Utilities
{
    public static class PasswordExtensions
    {
        /// <summary>
        /// Hashes the plain text password using BCrypt.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <returns>The hashed password.</returns>
        public static string HashPassword(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Verifies the plain text password against the hashed password.
        /// </summary>
        /// <param name="plainPassword">The plain text password to verify.</param>
        /// <param name="hashedPassword">The hashed password to verify against.</param>
        /// <returns>True if the passwords match, false otherwise.</returns>
        public static bool VerifyPassword(this string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}