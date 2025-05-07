using System.Security.Cryptography;
using System.Text;
/// <summary>
/// Clase responsable de realizar operaciones de encriptación.
/// </summary>
public class EncryptLogic
{
    /// <summary>
    /// Obtiene el hash SHA256 de un string.
    /// </summary>
    /// <param name="str">Texto a encriptar.</param>
    /// <returns>Cadena encriptada en formato hexadecimal.</returns>
    public static string GetSHA256(string str)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] stream = sha256.ComputeHash(Encoding.ASCII.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }
    }
}
