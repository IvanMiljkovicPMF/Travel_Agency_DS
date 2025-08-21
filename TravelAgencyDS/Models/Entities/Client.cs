using System;
using System.Collections.Generic;
using Utils.Encryption;

namespace Models.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Private backing field to store encrypted passport number
        private string _passportNumber;

        // Encrypt/Decrypt automatically
        public string PassportNumber
        {
            get => EncryptionHelper.Decrypt(_passportNumber);
            set => _passportNumber = EncryptionHelper.Encrypt(value);
        }

        // Private backing field to store encrypted email
        private string _email;

        public string Email
        {
            get => EncryptionHelper.Decrypt(_email);
            set => _email = EncryptionHelper.Encrypt(value);
        }

        // Private backing field to store encrypted phone number
        private string _phoneNumber;

        public string PhoneNumber
        {
            get => EncryptionHelper.Decrypt(_phoneNumber);
            set => _phoneNumber = EncryptionHelper.Encrypt(value);
        }

        public DateTime DateOfBirth { get; set; }

        // A client can book multiple packages
        public ICollection<TravelPackage> TravelPackages { get; set; } = new List<TravelPackage>();
    }
}
