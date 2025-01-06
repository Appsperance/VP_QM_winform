using System;
using System.Security.Cryptography;
using System.Text;


namespace VP_QM_winform.Helper
{
    public class PasswordHasher
    {
        /// <summary>
        /// Generate a hashed password and a fixed 22-character salt.
        /// </summary>
        /// <param name="targetPwd">The raw password to hash.</param>
        /// <param name="salt">The 22-character random salt.</param>
        /// <returns>The Base64-encoded hashed password.</returns>
        public static string GenerateHash(string targetPwd, out string salt)
        {
            // Generate a 16-byte random salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes); // Fill the byte array with random bytes
            }
            salt = Convert.ToBase64String(saltBytes);

            // Ensure the salt is exactly 22 characters
            salt = salt.Length > 22 ? salt.Substring(0, 22) : salt.PadRight(22, 'A');

            // Combine the password and salt, then compute the SHA256 hash
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPwd = Encoding.UTF8.GetBytes(targetPwd + salt);
                byte[] hashedPwd = sha256.ComputeHash(saltedPwd);

                // Return the Base64-encoded hash
                return Convert.ToBase64String(hashedPwd);
            }
        }

        /// <summary>
        /// Verify that the raw password, when hashed with the stored salt, matches the stored hash.
        /// </summary>
        /// <param name="targetPwd">The raw password to verify.</param>
        /// <param name="storedSalt">The 22-character salt used to generate the stored password.</param>
        /// <param name="storedHash">The Base64-encoded hashed password to compare against.</param>
        /// <returns>True if the password is valid; false otherwise.</returns>
        public static bool VerifyHash(string targetPwd, string storedSalt, string storedHash)
        {
            // Combine the password and stored salt, then compute the SHA256 hash
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedTargetPwd = Encoding.UTF8.GetBytes(targetPwd + storedSalt);
                byte[] hashedTargetPwd = sha256.ComputeHash(saltedTargetPwd);

                // Compare the computed hash with the stored hash
                return Convert.ToBase64String(hashedTargetPwd) == storedHash;
            }
        }
    }
}