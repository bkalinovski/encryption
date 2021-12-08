using System;
using Encryption.Contract;
using Encryption.Contract.Models;
using Encryption.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace Encryption.Host.Controllers
{
    public class EncryptionController : Controller
    {
        private readonly ISymmetricEncryption _symmetricService;
        private readonly IAsymmetricEncryption _asymmetricService;
        private readonly IKey _keyService;

        public EncryptionController(ISymmetricEncryption symmetricService, IAsymmetricEncryption asymmetricService, IKey keyService)
        {
            _symmetricService = symmetricService;
            _asymmetricService = asymmetricService;
            _keyService = keyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SymmetricEncryption()
        {
            return View(new SymmetricViewModel());
        }

        [HttpPost]
        public IActionResult SymmetricEncryption(SymmetricViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Provided model is not valid");
            }
            
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("password", "Password is missing.");
            }
            
            if (model.Action == EncryptionType.Encryption && string.IsNullOrEmpty(model.OriginalText))
            {
                ModelState.AddModelError("originalText", "Original text cannot be empty");
            }
            
            if (model.Action == EncryptionType.Decryption && string.IsNullOrEmpty(model.EncryptedText))
            {
                ModelState.AddModelError("encryptedText", "Encrypted text cannot be empty");
            }
            
            if (ModelState.ErrorCount > 0)
            {
                return View(model);   
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
        public IActionResult AsymmetricEncryption(AsymmetricViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Provided model is not valid");
            }

            if (model.Action == EncryptionType.Encryption && string.IsNullOrEmpty(model.PublicKey))
            {
                ModelState.AddModelError("publicKey", "Public key is missing. Choose one!");
            }
            
            if (model.Action == EncryptionType.Decryption && string.IsNullOrEmpty(model.PrivateKey))
            {
                ModelState.AddModelError("privateKey", "Private key is missing. Choose one!");
            }
            
            if (model.Action == EncryptionType.Encryption && string.IsNullOrEmpty(model.OriginalText))
            {
                ModelState.AddModelError("originalText", "Original text cannot be empty");
            }
            
            if (model.Action == EncryptionType.Decryption && string.IsNullOrEmpty(model.EncryptedText))
            {
                ModelState.AddModelError("encryptedText", "Encrypted text cannot be empty");
            }
            
            ViewBag.PublicKeys = _keyService.ListKeys();

            if (ModelState.ErrorCount > 0)
            {
                return View(model);   
            }

            switch (model.Action)
            {
                case EncryptionType.Encryption:
                    model.EncryptedText = _asymmetricService.Encrypt(model.OriginalText, model.PublicKey);
                    break;
                case EncryptionType.Decryption:
                    model.OriginalText = _asymmetricService.Decrypt(model.EncryptedText, model.PrivateKey);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult AsymmetricEncryption()
        {
            ViewBag.PublicKeys = _keyService.ListKeys();
            return View(new AsymmetricViewModel());
        }
        
        public IActionResult RemovePublicKey(Guid publicKeyId)
        {
            _keyService.EraseKey(publicKeyId);
            return RedirectToAction("AsymmetricEncryption");
        }
        
        [HttpPost]
        public IActionResult AddPublicKey(string title, string value)
        {
            _keyService.AddKey(new PublicKey(title, value));
            return RedirectToAction("AsymmetricEncryption");
        }
    }
}