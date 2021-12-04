using System;
using Encryption.Contract;
using Encryption.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace Encryption.Host.Controllers
{
    public class EncryptionController : Controller
    {
        private readonly ISymmetricEncryption _symmetricService;

        public EncryptionController(ISymmetricEncryption symmetricService)
        {
            _symmetricService = symmetricService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SymmetricEncryption()
        {
            var model = new EncryptionViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SymmetricEncryption(EncryptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Provided model is not valid");
            }
            
            switch (model.Action)
            {
                case EncryptionType.Encryption:
                    model.EncryptedText = _symmetricService.Encrypt(model.OriginalText, model.Password);
                    break;
                case EncryptionType.Decryption:
                    model.OriginalText = _symmetricService.Decrypt(model.EncryptedText, model.Password);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return View(model);
        }
        
        [HttpPost]
        public IActionResult AsymmetricEncryption(EncryptionViewModel model)
        {
            var action = model.Action == EncryptionType.Encryption ? "Encrypted" : "Decrypted";
            model.EncryptedText = $"{action} '{model.OriginalText}' with password: {model.Password}";
            
            return View(model);
        }
        
        public IActionResult AsymmetricEncryption()
        {
            return View();
        }
    }
}