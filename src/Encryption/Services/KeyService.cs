using System;
using System.Collections.Generic;
using System.Linq;
using Encryption.Contract;
using Encryption.Contract.Models;

namespace Encryption.Services
{
    public class KeyService : IKey
    {
        private readonly List<PublicKey> list;
        
        public KeyService()
        {
            list = new List<PublicKey>();
        }

        public IEnumerable<PublicKey> ListKeys()
        {
            return list;
        }

        public PublicKey GetKeyById(Guid id)
        {
            return list.FirstOrDefault(key => key.Id == id);
        }

        public void AddKey(PublicKey key)
        {
            if (key == null)
            {
                throw new Exception("Cannot add an empty key");
            }
            
            if (string.IsNullOrEmpty(key.Value))
            {
                throw new Exception("Cannot add a key with an empty value");
            }
            
            list.Add(key);
        }

        public void EraseKey(PublicKey key)
        {
            list.Remove(key);
        }

        public void EraseKey(Guid id)
        {
            var key = GetKeyById(id);

            if (key == null)
            {
                return;
            }

            EraseKey(key);
        }
    }
}