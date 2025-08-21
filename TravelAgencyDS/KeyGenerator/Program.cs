using System;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        byte[] key = new byte[32]; // 32 bytes = 256-bit AES
        byte[] iv = new byte[16];  // 16 bytes = AES block size

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
            rng.GetBytes(iv);
        }

        Console.WriteLine("AES Key: " + Convert.ToBase64String(key));
        Console.WriteLine("AES IV: " + Convert.ToBase64String(iv));
    }
}