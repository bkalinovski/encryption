using System;
using System.Collections.Generic;
using Encryption.Contract.Models;

namespace Encryption.Contract
{
    public interface IKey
    {
        IEnumerable<PublicKey> ListKeys();

        PublicKey GetKeyById(Guid id);

        void AddKey(PublicKey key);

        void EraseKey(PublicKey key);

        void EraseKey(Guid id);
    }
}