using System;
using Encryption.Contract;
using Encryption.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace Encryption.Host.Controllers
{
    public class EncryptionController : Controller
    {
        private readonly ISymmetricEncryption _symmetricService;
        private readonly IAsymmetricEncryption _asymmetricService;

        public EncryptionController(ISymmetricEncryption symmetricService, IAsymmetricEncryption asymmetricService)
        {
            _symmetricService = symmetricService;
            _asymmetricService = asymmetricService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SymmetricEncryption()
        {
            return View(new EncryptionViewModel());
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
            if (!ModelState.IsValid)
            {
                throw new Exception("Provided model is not valid");
            }
            
            switch (model.Action)
            {
                case EncryptionType.Encryption:
                    model.EncryptedText = _asymmetricService.Encrypt(model.OriginalText, model.Password);
                    break;
                case EncryptionType.Decryption:
                    model.OriginalText = _asymmetricService.Decrypt(model.EncryptedText, model.Password);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult AsymmetricEncryption()
        {
            return View(new EncryptionViewModel());
        }
    }
}