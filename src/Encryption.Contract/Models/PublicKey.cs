using System;

namespace Encryption.Contract.Models
{
    public class PublicKey
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }

        public DateTime InsertDate { get; set; }

        public PublicKey(string title, string value)
        {
            Id = Guid.NewGuid();
            Title = title;
            Value = value;
            InsertDate = DateTime.Now;
        }
    }
}