using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Encryption;

namespace Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        // Encrypted Passport Number
        private string _passportNumber;

        [Required, MaxLength(20)]
        public string PassportNumber
        {
            get => EncryptionHelper.Decrypt(_passportNumber);
            set => _passportNumber = EncryptionHelper.Encrypt(value);
        }

        public DateTime DateOfBirth { get; set; }

        // Encrypted Email
        private string _email;
        [Required, EmailAddress]
        public string Email
        {
            get => EncryptionHelper.Decrypt(_email);
            set => _email = EncryptionHelper.Encrypt(value);
        }

        // Encrypted Phone Number
        private string _phoneNumber;
        [Required, Phone]
        public string PhoneNumber
        {
            get => EncryptionHelper.Decrypt(_phoneNumber);
            set => _phoneNumber = EncryptionHelper.Encrypt(value);
        }

        // Navigacija prema rezervacijama (junction table)
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
