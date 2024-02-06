using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        // Encryption endpoint
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string plainText)
        {
            // Implement your encryption logic here (e.g., Caesar cipher)
            // For simplicity, this example uses a Caesar cipher with shift=3
            char[] chars = plainText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = (char)(chars[i] + 3);
                    if (!char.IsLetter(chars[i]))
                    {
                        chars[i] = (char)(chars[i] - 26);
                    }
                }
            }
            string encryptedText = new string(chars);

            return Ok(new { encryptedText });
        }
        // Decryption endpoint
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string encryptedText)
        {
            // Implement your decryption logic here (reverse of encryption)
            char[] chars = encryptedText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = (char)(chars[i] - 3);
                    if (!char.IsLetter(chars[i]))
                    {
                        chars[i] = (char)(chars[i] + 26);
                    }
                }
            }
            string decryptedText = new string(chars);

            return Ok(new { decryptedText });
        }

    }
}